using Mango.Services.AuthAPI.Models.Dtos;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    /// <summary>
    /// Information of auth controller
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDto registerationRequestDto)
        {
            var response = new ResponseDto();

            var errorMessage = await _authService.Register(registerationRequestDto);

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                response.IsSuccess = false;
                response.Message = errorMessage;

                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = new ResponseDto();

            var loginResponse = await _authService.Login(loginRequestDto);

            if (loginResponse.User == null)
            {
                response.IsSuccess = false;
                response.Message = "Username or password is incorrect";

                return BadRequest(response);
            }

            response.Result = loginResponse;
            return Ok(response);
        }
    }
}