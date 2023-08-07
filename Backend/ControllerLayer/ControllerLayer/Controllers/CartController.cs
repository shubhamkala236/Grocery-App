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
    public class CartController : ControllerBase
    {
        private readonly ICartBLL cartBLL;

        public CartController(ICartBLL cartBLL)
        {
            this.cartBLL = cartBLL;
        }

        //Add to cart from productDetails page
        [HttpPost("addToCart")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddToCart([FromForm]AddToCartDto addToCartDto)
        {
            try
            {
                //get userId from token
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    //if not null set dto userID 
                    addToCartDto.UserId = userId;
                }
                else
                {
                    return BadRequest("User not valid");
                }
                if(addToCartDto.QuantityAdded==0)
                {
                    return Ok("Added '0' quantity");
                }
                var result = await cartBLL.AddToCart(addToCartDto);
                if (result)
                {
                    return Ok("CartItem Added successfully");
                }
                return StatusCode(500, "An Error Occurred While adding CartItem check if already exists in your cart");

            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //get cartItems
        [HttpGet("myCart")]
        public async Task<IActionResult> GetMyCart()
        {
            try
            {
                //get current User from token
                var userId = GetCurrentUser();
                if(userId==0)
                {
                    return StatusCode(500, "Not Valid user please login");
                }
                var result = await cartBLL.GetMyCart(userId);
                if(result==null)
                {
                    return StatusCode(500, "Unable to get cart items");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

    

        //delete cartItem
        [HttpDelete("deleteCartItem/{productId}")]
        public async Task<IActionResult> DeleteCartItem(int productId)
        {
            try
            {
                var userId = GetCurrentUser();
                if(userId==0)
                {
                    return StatusCode(500, "Not Valid user please login");
                }
                var result = await cartBLL.DeleteFromCart(productId,userId);
                if (result != null)
                {
                    return Ok("Cart Item Deleted Successfully");
                }

                return NotFound("Cart Item not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }


        //get current user
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
