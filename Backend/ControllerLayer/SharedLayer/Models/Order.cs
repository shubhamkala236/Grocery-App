using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Unique Id is required")]
        public string UniqueOrderId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Order Quantity is required")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "ImageUrl  is required")]
        public string OrderImageUrl { get; set; }

        [Required(ErrorMessage = "Order name Url is required")]
        public string OrderName { get; set; }
    }
}
