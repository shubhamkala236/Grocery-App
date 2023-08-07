using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class LoginResponseDto
    {        
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
