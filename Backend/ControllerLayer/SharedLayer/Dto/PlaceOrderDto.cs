using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class PlaceOrderDto
    {

        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        public int OrderQuantityDto { get; set; }

        [Required(ErrorMessage = "Order Image Url is required")]
        public string OrderImageUrl { get; set; }

        [Required(ErrorMessage = "Order Image Url is required")]
        public string OrderName { get; set; }
    }
}
