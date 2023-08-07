using Microsoft.AspNetCore.Http;
using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CartBLL : ICartBLL
    {
        private readonly IUnitOfWork uow;

        public CartBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> AddToCart(AddToCartDto cartItemDto)
        {
            //convert cartDto ---> cart
            //get userId from jwt token

            var cartItem = new Cart
            {
                UserId = cartItemDto.UserId,
                ProductId = cartItemDto.ProductId,
                QuantityAdded = cartItemDto.QuantityAdded,
            };

            var result = await uow.CartRepository.AddToCart(cartItem);
            await uow.SaveAsync();
            return result;
        }

        //delete
        public async Task<Cart> DeleteFromCart(int productId, int userId)
        {
            var result = await uow.CartRepository.DeleteFromCart(productId, userId);
            await uow.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<DisplayProductDto>> GetMyCart(int userId)
        {
            var result = await uow.CartRepository.GetMyCartItems(userId);
            //convert list of products to display product dto
            var displayProductDtoList = result.Select(p => new DisplayProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Category = p.Category,
                Quantity = p.Quantity,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Discount = p.Discount,
                Specification = p.Specification,
            }).ToList();

            return displayProductDtoList;
        }
    }
}
