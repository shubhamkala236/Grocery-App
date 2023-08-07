using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Dto
{
    public class TestDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Product Name must be alphanumeric.")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        //[AllowedExtensions(new[] {".jpg",".jpeg",".png" },ErrorMessage ="Image Format must be in JPG or PNG format")]
        public IFormFile ImageFile { get; set; }
    }
}
