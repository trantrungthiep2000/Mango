using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dtos;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Services
{
    /// <summary>
    /// Information of auth service
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        
        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>Information of user and token</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var userByUsername = await _appDbContext.applicationUsers.FirstOrDefaultAsync(u => u.UserName!.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(userByUsername!, loginRequestDto.Password);

            if (userByUsername == null || isValid == false)
            {
                return new LoginResponseDto(){ User = null!, Token = "", };
            }

            var token = _jwtTokenGenerator.GenerateToken(userByUsername);

            User user = new User()
            {
                Email = userByUsername.Email!,
                ID = userByUsername.Id,
                Name = userByUsername.Name,
                PhoneNumber = userByUsername.PhoneNumber!,
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto() { User = user, Token = token };

            return loginResponseDto;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>Information</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
        {
            try
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = registerationRequestDto.Email,
                    Email = registerationRequestDto.Email,
                    NormalizedEmail = registerationRequestDto.Email.ToUpper(),
                    Name = registerationRequestDto.Name,
                    PhoneNumber = registerationRequestDto.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(applicationUser, registerationRequestDto.Password);

                if (result.Succeeded)
                {
                    var userByEmail = await _appDbContext.applicationUsers.FirstOrDefaultAsync(u => u.UserName == registerationRequestDto.Email);

                    User user = new User()
                    {
                        Email = userByEmail!.Email!,
                        ID = userByEmail.Id,
                        Name = userByEmail.Name,
                        PhoneNumber = userByEmail.PhoneNumber!,
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault()!.Description;
                }
            }
            catch (Exception ex)
            {

            }

            return "Error Encountered";
        }
    }
}
