using SharedLayer.Dto;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface ICartBLL
    {
        //Add to cart 
        Task<bool> AddToCart(AddToCartDto cartItem);
        //Get my CartItems
        Task<IEnumerable<DisplayProductDto>> GetMyCart(int userId);
        //delete
        Task<Cart> DeleteFromCart(int productId,int userId);


    }
}
