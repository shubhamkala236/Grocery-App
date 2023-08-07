using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface ICartRepository
    {
        Task<bool> AddToCart(Cart product);
        Task<IEnumerable<Product>> GetMyCartItems(int userId);

        Task<Cart> DeleteFromCart(int productId,int userId);


    }
}
