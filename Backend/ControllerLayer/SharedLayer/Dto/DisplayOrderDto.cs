using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class DisplayOrderDto
    {

        [Required(ErrorMessage = "Unique Id is required")]
        public string UniqueOrderId { get; set; }

        [Required(ErrorMessage = "Order Quantity is required")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Image Url is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Order name Url is required")]
        public string OrderName { get; set; }

    }
}
