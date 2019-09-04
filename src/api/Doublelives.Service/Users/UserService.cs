using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Doublelives.Data;
using Doublelives.Domain.Users;
using Doublelives.Shared.ConfigModels;
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Doublelives.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtOptions _jwtConfig;

        public UserService(IUnitOfWork unitOfWork, IOptions<JwtOptions> jwtOptions)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
        }

        public string GenerateToken(string id)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience, _jwtConfig.Audience),
                    new Claim(JwtClaimTypes.Issuer, _jwtConfig.Issuer),
                    new Claim(JwtClaimTypes.Subject, id),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(securityToken);

            return tokenString;
        }

        public User GetById(string id)
        {
            var guid = Guid.Parse(id);

            return _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefault(it => it.Id == guid);
        }
    }
}
