using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Proxies;
using AbcBlog.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AbcBlog.Infrastructure.Proxies
{
    public class TokenProxy : ITokenProxy
    {
        public TokenProxy(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IConfiguration Configuration { get; set; }

        public AccessToken CreateAccessToken(User user)
        {
            SymmetricSecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            AccessToken accessToken = new AccessToken()
            {
                ExpireDate = DateTime.Now.AddMinutes(5)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Configuration["Token:Issuer"],
                Audience = Configuration["Token:Audience"],
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim("Email", user.Email.ToString()),
                }),
                Expires = accessToken.ExpireDate,
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            accessToken.Token = tokenHandler.WriteToken(token);

            return accessToken;
        }
    }
}
