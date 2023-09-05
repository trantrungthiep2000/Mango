using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Information of auth controller
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        [HttpGet]
        public IActionResult Login()
        {
            var loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var responseDto = await _authService.LoginAsync(loginRequestDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                var loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result)!);

                await SignInUser(loginResponseDto!);
                _tokenProvider.SetToken(loginResponseDto!.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDto!.Message;
                return View(loginRequestDto);
            }
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        [HttpGet]
        public IActionResult Register()
        {
            var roles = new List<SelectListItem>()
            {
                new SelectListItem() { Text = SD.RoleAdmin, Value = SD.RoleAdmin },
                new SelectListItem() { Text = SD.RoleCustomer, Value = SD.RoleCustomer },
            };

            ViewBag.roles = roles;
            return View();
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto registerationRequestDto)
        {
            var result = await _authService.RegisterAsync(registerationRequestDto);
            var assingRole = new ResponseDto();

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrWhiteSpace(registerationRequestDto.RoleName))
                {
                    registerationRequestDto.RoleName = SD.RoleCustomer;
                }

                var assignRoleRequestDto = new AssignRoleRequestDto()
                {
                    Email = registerationRequestDto.Email,
                    RoleName = registerationRequestDto.RoleName,
                };

                assingRole = await _authService.AssignRoleAsync(assignRoleRequestDto);

                if (assingRole != null && assingRole.IsSuccess)
                {
                    TempData["success"] = "Registration successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result!.Message;
            }

            var roles = new List<SelectListItem>()
            {
                new SelectListItem() { Text = SD.RoleAdmin, Value = SD.RoleAdmin },
                new SelectListItem() { Text = SD.RoleCustomer, Value = SD.RoleCustomer },
            };

            ViewBag.roles = roles;
            return View(registerationRequestDto);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.CleanToken();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(loginResponseDto.Token);    
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)!.Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)!.Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name)!.Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)!.Value));
            identity.AddClaim(new Claim(ClaimTypes.Name,
              jwt.Claims.FirstOrDefault(u => u.Type == "role")!.Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
