using SharedLayer.Dto;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IProductsBLL
    {
        //add products
        Task<bool> AddProduct(AddProductDto product);

        //get products
        Task<IEnumerable<DisplayProductDto>> GetAllProducts();
        //get products based on category
        Task<IEnumerable<DisplayProductDto>> GetProductByCategory(string category);
        //remove products
        Task<Product> DeleteProduct(int productId);
        //update products
        Task<DisplayProductDto> UpdateProduct(int productId, AddProductDto updateProduct);
        //product details
        Task<DisplayProductDto> ProductDetails(int id);
    }
}
