using SharedLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IUserBLL
    {
        Task<bool> RegisterUser(RegisterUserDto user);
        Task<LoginResponseDto> LoginUser(LogInUserDto user);

    }
}
