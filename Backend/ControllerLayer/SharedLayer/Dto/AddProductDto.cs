using Microsoft.AspNetCore.Http;
using SharedLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class AddProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Product Name must be alphanumeric.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Description must be alphanumeric.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Category must be alphanumeric.")]
        public string Category { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Available Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Image Format must be in JPG or PNG format")]
        public IFormFile ImageFile { get; set; }


        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount must be a positive number.")]
        public decimal? Discount { get; set; }

        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Specification must be alphanumeric.")]
        public string Specification { get; set; }
    }
}
