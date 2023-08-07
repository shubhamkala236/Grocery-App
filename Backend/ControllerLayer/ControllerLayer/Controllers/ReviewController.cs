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
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewBLL reviewBLL;

        public ReviewController(IReviewBLL reviewBLL)
        {
            this.reviewBLL = reviewBLL;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromForm] AddReviewDto addReviewDto)
        {
            try
            {
                var result = await reviewBLL.AddReview(addReviewDto);
                if (result)
                {
                    return Ok("Product Added successfully");
                }
                return StatusCode(409, "An Error Occurred While adding Review");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        [HttpGet("productReview/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductReview(int id)
        {
            try
            {
                var result = await reviewBLL.GetProductReviews(id);
                if(result!=null)
                {
                    return Ok(result);
                }
                return StatusCode(404, "No Reviews in databse");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }
    }
}
