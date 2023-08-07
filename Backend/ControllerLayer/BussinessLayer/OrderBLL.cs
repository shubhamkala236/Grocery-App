using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class OrderBLL : IOrderBLL
    {
        private readonly IUnitOfWork uow;

        public OrderBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<DisplayOrderDto>> GetMyOrders(int userId)
        {
            var result = await uow.OrderRepository.GetMyOrders(userId);

            //convert list of orders to displayOrderDto
            var displayOrderDtoList = result.Select(o => new DisplayOrderDto
            {
                UniqueOrderId = o.UniqueOrderId,
                OrderQuantity = o.OrderQuantity,
                OrderDate = o.OrderDate,
                ImageUrl = o.OrderImageUrl,
                OrderName = o.OrderName,

            }).ToList();

            return displayOrderDtoList;

        }

        public async Task<IEnumerable<TopOrdersDto>> GetTopOrders(int month, int year)
        {
            var result = await uow.OrderRepository.GetTopOrders(month, year);
            return result;
            
        }

        public async Task<bool> PlaceOrder(PlaceOrderDto placedOrder, int userId)
        {
            //convert into Order entity
            var uniqueId = Guid.NewGuid().ToString();
            var newOrder = new Order
            {
                UniqueOrderId = uniqueId,
                UserId = userId,
                ProductId = placedOrder.ProductId,
                OrderQuantity = placedOrder.OrderQuantityDto,
                OrderDate = DateTime.Now,
                OrderImageUrl = placedOrder.OrderImageUrl,
                OrderName = placedOrder.OrderName
            };

            var result = await uow.OrderRepository.PlaceOrder(newOrder);
            await uow.SaveAsync();
            return result;
        }
    }
}
