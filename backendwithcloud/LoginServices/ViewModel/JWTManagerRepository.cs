using LoginServices.Interfaces;
using LoginServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginServices.ViewModel
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        Dictionary<string, string> userRecords;
        private readonly IConfiguration configuration;
        private readonly onlineshoppingContext db;
        public JWTManagerRepository(IConfiguration _configuration, onlineshoppingContext _db)
        {
            configuration = _configuration;
            db = _db;
        }
        public Tokens Authenticate(LoginViewModel users)
        {
            // throw new NotImplementedException();
            userRecords = db.Userstbls.ToList().ToDictionary(x => x.Email, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if(!userRecords.Any(x=>x.Key==users.Email && x.Value ==users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.Email)
                }),
               Expires=DateTime.UtcNow.AddMinutes(10),
               SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
