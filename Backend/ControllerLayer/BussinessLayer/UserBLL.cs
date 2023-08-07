using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class UserBLL : IUserBLL
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public UserBLL(IUnitOfWork uow, IMapper mapper,IConfiguration config)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.config = config;
        }

        
        //Register User
        public async Task<bool> RegisterUser(RegisterUserDto userDto)
        {
            byte[] passwordHash, passwordKey;
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userDto.Password));
            }

            //var newUser = new User
            //{
            //    Name = userDto.Name,
            //    Email = userDto.Email,
            //    Password = passwordHash,
            //    PasswordKey = passwordKey,
            //    PhoneNumber = userDto.PhoneNumber,
            //    isAdmin = false,
            //};
            var newUser = mapper.Map<User>(userDto);
            newUser.Password = passwordHash;
            newUser.PasswordKey = passwordKey;
            newUser.isAdmin = false;
            
            
            var result = await uow.UserRepository.Register(newUser);
            await uow.SaveAsync();
            return result;

        }

        //Login User
        public async Task<LoginResponseDto> LoginUser(LogInUserDto user)
        {
            var result = await uow.UserRepository.Login(user.Email, user.Password);
            if (result!=null)
            {
                var loginResponse = new LoginResponseDto();
                loginResponse.Email = user.Email;
                loginResponse.Token = CreateJWT(result);
                return loginResponse;
            }
            return null;
        }


        //JWT Token
        private string CreateJWT(User user)
        {
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("shh.. this is secret key"));
            var secretKey = config.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Name,user.isAdmin.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                
            };

            // Add role claims
            if (user.isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

       
    }
}
