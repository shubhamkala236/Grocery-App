using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Dto;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControllerLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBLL orderBLL;

        public OrderController(IOrderBLL orderBLL)
        {
            this.orderBLL = orderBLL;
        }

        //Place order from my CArt page
        [HttpPost("placeOrder")]
        public async Task<IActionResult> PlaceOrder([FromForm] PlaceOrderDto placedOrder)
        {
            try
            {
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }
                var result = await orderBLL.PlaceOrder(placedOrder,userId);
                if (result)
                {
                    return Ok("Order Placed Successfully");
                }
                //quantity may be exceeding available quantity
                return StatusCode(400,"Quantity is not available");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Get My Orders
        [HttpGet("myOrders")]
        public async Task<IActionResult> GetMyOrder()
        {
            try
            {
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }

                var result = await orderBLL.GetMyOrders(userId);
                if(result ==null)
                {
                    return NotFound("Order not found for this user");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Get top orders
        [HttpGet("topOrders")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetTopOrders(int month,int year)
        {
            try
            {
                var result = await orderBLL.GetTopOrders(month, year);
                if (result == null)
                {
                    return NotFound("Order not found");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        private int GetCurrentUser()
        {
            //get userId from token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                //if not null set dto userID 
                return userId;
            }
            return 0;
        }


    }
}
