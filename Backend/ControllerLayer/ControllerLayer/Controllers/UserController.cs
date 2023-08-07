using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Dto;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL userBLL;
        private readonly IMapper mapper;

        public UserController(IUserBLL userBLL,IMapper mapper)
        {
            this.userBLL = userBLL;
            this.mapper = mapper;
        }
        //Register User
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm]RegisterUserDto user)
        {
            try
            {
                var result = await userBLL.RegisterUser(user);
                if (result)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500,"An Error Occurred While inserting User");
            }
            catch(Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Login User
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromForm]LogInUserDto user)
        {
            try
            {
                var response = await userBLL.LoginUser(user);
                if (response!=null)
                {
                    return Ok(response);
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }


    }
}
