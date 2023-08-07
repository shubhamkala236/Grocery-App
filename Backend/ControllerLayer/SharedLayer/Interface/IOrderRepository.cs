using SharedLayer.Dto;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IOrderRepository
    {
        Task<bool> PlaceOrder(Order order);
        Task<IEnumerable<Order>> GetMyOrders(int userId);
        Task<IEnumerable<TopOrdersDto>> GetTopOrders(int month,int year);
    }
}
