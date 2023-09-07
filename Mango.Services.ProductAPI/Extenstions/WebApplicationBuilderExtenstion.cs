using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Mango.Services.ProductAPI.Extenstions
{
    /// <summary>
    /// Information of web application builder extenstion
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public static class WebApplicationBuilderExtenstion
    {
        /// <summary>
        /// Add application authentication
        /// </summary>
        /// <param name="builder"><WebApplicationBuilder/param>
        /// <returns>WebApplicationBuilder</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
        {
            var settingsSection = builder.Configuration.GetSection("ApiSettings");

            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var audience = settingsSection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret!);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true,
                };
            });

            return builder;
        }
    }
}
