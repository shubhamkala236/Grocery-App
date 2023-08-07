using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly GroceryDbContext context;

        public UserRepository(GroceryDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(user == null)
            {
                return null;
            }
            if(!MatchPasswordHash(password,user.Password,user.PasswordKey))
            {
                return null;
            }
            return user;

        }

        public async Task<bool> Register(User user)
        {
            if(context.Users.Any(x => x.Email == user.Email))
            {
                return false;
            }

            await context.Users.AddAsync(user);
            
            return true;
        }

        private bool MatchPasswordHash(string passwordText,byte[] password,byte[] passwordKey)
        {
            using(var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for(int index=0;index<passwordHash.Length;index++)
                {
                    if(passwordHash[index]!=password[index])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}
