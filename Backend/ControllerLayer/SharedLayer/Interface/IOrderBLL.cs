using SharedLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IOrderBLL
    {
        Task<bool> PlaceOrder(PlaceOrderDto placedOrder,int userId);
        Task<IEnumerable<DisplayOrderDto>> GetMyOrders(int userId);
        Task<IEnumerable<TopOrdersDto>> GetTopOrders(int month,int year);

    }
}
