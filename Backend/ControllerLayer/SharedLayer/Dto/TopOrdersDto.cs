using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class TopOrdersDto
    {

        public int ProductId { get; set; }
        public int TotalOrders { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
    }
}
