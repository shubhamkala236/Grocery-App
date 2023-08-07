using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductByCategorys(string category);
        Task<Product> DeleteProduct(int productId);
        Task<Product> EditProduct(int id, Product updatedProduct);
        Task<Product> ProductDetails(int id);

    }
}
