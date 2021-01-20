using VintageShop.Models;
using VintageShop.Enums;
using VintageShop.IRepositories;
using VintageShop.IServices;
using VintageShop.Mapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VintageShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            this._userRepository = userRepository;
            this._appSettings = appSettings.Value;
        }

        public bool Register(AuthenticationRequest request)
        {
            var entity = request.ToUserExtension(Enums.UserTypeEnum.Client);

            _userRepository.Create(entity);
            return _userRepository.SaveCh();
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAllActive();
        }

        public User GetById(int id)
        {
            return _userRepository.FindById(id);
        }

        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // find user
            var user = _userRepository.GetByUserAndPassword(request.Username, request.Password);
            if (user == null)
                return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthenticationResponse
            {
                Id = user.Id,
                Username = user.Username,
                Type = user.Type,
                Token = token
            };
        }

        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
