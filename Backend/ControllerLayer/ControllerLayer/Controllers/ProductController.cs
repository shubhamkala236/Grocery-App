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
    public class ProductController : ControllerBase
    {
        private readonly IProductsBLL productsBLL;

        public ProductController(IProductsBLL productsBLL)
        {
            this.productsBLL = productsBLL;
        }

        //Add Product------------Admin
        [HttpPost("addProduct")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AddProduct([FromForm]AddProductDto productDto)
        {
            try
            {
                var result = await productsBLL.AddProduct(productDto);
                if (result)
                {
                    return Ok("Product Added successfully");
                }
                return StatusCode(409, "An Error Occurred While adding Product");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //GetAll Product
        [HttpGet("allProducts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await productsBLL.GetAllProducts();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Delete Product------------Admin
        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await productsBLL.DeleteProduct(id);
                if(product!=null)
                {
                    return Ok("Product Deleted Successfully");
                }

                return NotFound("Product not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Update Product------------Admin
        [HttpPut("update/{id}")]
        [Consumes("multipart/form-data")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateProduct(int id,[FromForm]AddProductDto productDto)
        {
            try
            {
                var result = await productsBLL.UpdateProduct(id,productDto);
                if(result!=null)
                {
                    return Ok(result);
                }
                return StatusCode(500, "An Error Occurred While Updating Product");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //Product details readonly----------User and admin
        [HttpGet("productDetails/{id}")]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> ProductDetails(int id)
        {
            try
            {
                //return a display product dto
                var result = await productsBLL.ProductDetails(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(500, "No Product Deatail with this id found");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }

        //getProducts by category
        [HttpGet("productCategory/{category}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProuctsByCategory(string category)
        {
            try
            {
                var result = await productsBLL.GetProductByCategory(category);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"An error occurred:{e.Message}");
            }
        }


    }
}
