using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GroceryDbContext context;

        public OrderRepository(GroceryDbContext context)
        {
            this.context = context;
        }

        //get my orders
        public async Task<IEnumerable<Order>> GetMyOrders(int userId)
        {
            var orders = await context.Orders.Where(o => o.UserId == userId).ToListAsync();
            return orders;
        }

        //get top orders
        public async Task<IEnumerable<TopOrdersDto>> GetTopOrders(int month, int year)
        {
            var monthStart = new DateTime(year, month, 1);
            var monthEnd = monthStart.AddMonths(1).AddSeconds(-1);

            var topOrders = await context.Orders
                .Where(o => o.OrderDate >= monthStart && o.OrderDate <= monthEnd)
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalOrders = g.Count()
                })
                .OrderByDescending(p => p.TotalOrders)
                .Take(5)
                .ToListAsync();

            var productIds = topOrders.Select(p => p.ProductId).ToList();

            var products = await context.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            var result = topOrders.Select(p => new TopOrdersDto
            {
                ProductId = p.ProductId,
                TotalOrders = p.TotalOrders,
                ProductName = products.FirstOrDefault(prod => prod.ProductId == p.ProductId)?.ProductName,
                ProductUrl = products.FirstOrDefault(prod => prod.ProductId == p.ProductId)?.ImageUrl
            });

            return result;
        }

        public async Task<bool> PlaceOrder(Order order)
        {
            //check in Cart table if valid product
            var cartItem = await context.Cart.FirstOrDefaultAsync(c => c.ProductId == order.ProductId && c.UserId == order.UserId);
            //check for product if in product table
            var product = await context.Products.FindAsync(order.ProductId);
            if(cartItem == null || product==null)
            {
                return false;
            }

            //check if order placed is for valid quantity
            var availableQuantity = product.Quantity;
            if(availableQuantity < order.OrderQuantity)
            {
                return false;
            }

            //add order
            //first delete cartItem for this id
            context.Cart.Remove(cartItem);
            //update product available quantity
            product.Quantity -= order.OrderQuantity;
            //save order
            await context.Orders.AddAsync(order);

            return true;

        }
    }
}
