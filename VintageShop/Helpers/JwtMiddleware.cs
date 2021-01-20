using VintageShop.Models;
using VintageShop.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageShop.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate del, IOptions<AppSettings> options)
        {
            _next = del;
            _appSettings = options.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContextByToken(context, userService, token);

            await _next(context);
        }

        private void AttachUserToContextByToken(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;
                var userId = int.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value);

                context.Items["User"] = userService.GetById(userId);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
