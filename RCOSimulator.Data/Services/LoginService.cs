using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Services
{
    public class LoginService : BaseService
    {
        public LoginService(IUnitOfWork uow) : base(uow)
        {
        }

        public LoginSuccessModel Login(LoginModel model) 
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.User),
                new Claim(ClaimTypes.Role, "Super Admin"),
                new Claim(ClaimTypes.NameIdentifier, model.Id)
            };

            var claimIdentity = new ClaimsIdentity(claims);
            var key = Encoding.ASCII.GetBytes(Constants.Secret);
            var jwtHandler = new JwtSecurityTokenHandler();
            var security = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Audience = Constants.ValidAudience,
                Issuer = Constants.ValidIssuer

            };
            var token = jwtHandler.CreateToken(security);
            return new LoginSuccessModel
            {
                AccessToken = jwtHandler.WriteToken(token),
            };
        }

        public bool IsTokenValid(string token)
        {
            if(string.IsNullOrEmpty(token)) return false;
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = true, // Because there is no audiance in the generated token
                ValidateIssuer = true,   // Because there is no issuer in the generated token
                ValidIssuer = Constants.ValidIssuer,
                ValidAudience = Constants.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.Secret)) // The same key as the one that generate the token
            };
        }
    }
}
