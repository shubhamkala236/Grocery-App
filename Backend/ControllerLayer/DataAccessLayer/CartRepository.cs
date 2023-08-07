using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CartRepository : ICartRepository
    {
        private readonly GroceryDbContext context;

        public CartRepository(GroceryDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddToCart(Cart cartItem)
        {
            //if user with same id and same productId already then do not add 
            var alreadyPresentItem = await context.Cart.FirstOrDefaultAsync(x => x.UserId == cartItem.UserId && x.ProductId == cartItem.ProductId);
            if (alreadyPresentItem!=null)
            {   
                //find the product quantity in Product table
                var originalProduct = await context.Products.FindAsync(cartItem.ProductId);
                var currentQuantityToAdd = cartItem.QuantityAdded;

                if(originalProduct!=null)
                {
                    var availableQuantity = originalProduct.Quantity;
                    var totalQuantity = currentQuantityToAdd + alreadyPresentItem.QuantityAdded;
                    if(totalQuantity > availableQuantity)
                    {
                        return false;
                    }
                    else
                    {
                        alreadyPresentItem.QuantityAdded = totalQuantity;
                        return true;
                    }
                }
                return false;
            }
            //check if addedQuantity greater than product quantity available
            var cartProduct = await context.Products.FindAsync(cartItem.ProductId);
            if(cartProduct!=null)
            {
                if(cartProduct.Quantity<cartItem.QuantityAdded)
                {
                    //cannot add to cart
                    return false;
                }
            }

            await context.Cart.AddAsync(cartItem);
            return true;
        }

        //delete from cart
        public async Task<Cart> DeleteFromCart(int productId, int userId)
        {
            var cartItem = await context.Cart.SingleOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
            if(cartItem==null)
            {
                return null;
            }

            context.Cart.Remove(cartItem);
            return cartItem;

        }

        public async Task<IEnumerable<Product>> GetMyCartItems(int userId)
        {
            //var myCartList = await context.Cart.Where(p => p.UserId == userId).ToListAsync();
            //from above list extract list of products by their id's
            //var cartProductsId = await context.Cart.Where(p => p.UserId == userId).Select(p => p.ProductId).ToListAsync();
            //var cartQuantity = await context.Cart.Where(p => p.UserId == userId).Select(p => p.QuantityAdded).ToListAsync();
            //var productList = await context.Products.Where(p => cartProductsId.Contains(p.ProductId)).ToListAsync();
            //return productList;


            var cartItems = await context.Cart
            .Where(p => p.UserId == userId)
            .Join(
                context.Products,
                cart => cart.ProductId,
                product => product.ProductId,
                (cart, product) => new { Product = product, Quantity = cart.QuantityAdded }).ToListAsync();

            var productList = cartItems.Select(item => item.Product);
            var cartQuantity = cartItems.Select(item => item.Quantity).ToList();

            // Update the Quantity field in productList based on cartQuantity
            for (int i = 0; i < productList.Count(); i++)
            {
                productList.ElementAt(i).Quantity = cartQuantity[i];
            }

            return productList;
        }
    }
}
