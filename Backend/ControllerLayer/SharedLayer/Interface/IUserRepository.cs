using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IUserRepository
    {
        Task<bool> Register(User user);
        Task<User> Login(string email, string password);
    }
}
