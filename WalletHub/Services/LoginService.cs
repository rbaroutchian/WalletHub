using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WalletHub.Data;
using WalletHub.Interfaces;

namespace WalletHub.Services
{
    public class LoginService : ILoginService
    {
        private const string HardcodedUsername = "admin";
        private const string HardcodedPassword = "admin";
        private const string HardcodedSecretKey = "sacsadf@!$%$fDSCSD4232342xsadf@!$%$fDSCSD4232342xsadf@!$%$fDSCSD4232342xsadf@!$%$fDSCSD4232342xsadf@!$%$fDSCSD4232342xsadf@!$%$fDSCSD4232342x";
       
        private readonly IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //private readonly string _issuer = configuration["Jwt:Issuer"];
        //private readonly string _audience = configuration["Jwt:Audience"];

        public bool Authenticate(string username)
        {
            // اعتبارسنجی نام کاربری و رمز عبور به صورت هارد کد
            return username == HardcodedUsername ;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(HardcodedSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                Audience = _configuration["Jwt:Audience"], // تنظیم مقدار Audience
                Issuer = _configuration["Jwt:Issuer"],     // تنظیم مقدار Issuer
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(HardcodedSecretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = bool.Parse(_configuration["Jwt:Issuer"]),
                    ValidateAudience = bool.Parse(_configuration["Jwt:Audience"]),
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

