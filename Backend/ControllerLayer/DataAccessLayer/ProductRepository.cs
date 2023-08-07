using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly GroceryDbContext context;

        public ProductRepository(GroceryDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddProduct(Product product)
        {
            if(await context.Products.AnyAsync(x => x.ProductName == product.ProductName))
            {
                return false;
            }
            await context.Products.AddAsync(product);
            return true;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var product = await context.Products.FindAsync(productId);
            if(product==null)
            {
                return null;
            }

            context.Products.Remove(product);

            return product;
        }

        public async Task<Product> EditProduct(int id, Product updatedProduct)
        {
            //find old product
            var product = await context.Products.FindAsync(id);
            if(product==null)
            {
                return null;
            }
            //remove old image
            //await photoService.DeletePhotoAsync(product.ImageCloudId);

            //updated product in database
            product.ProductName = updatedProduct.ProductName;
            product.Description = updatedProduct.Description;
            product.Category = updatedProduct.Category;
            product.Quantity = updatedProduct.Quantity;
            product.ImageUrl = updatedProduct.ImageUrl;
            product.ImageCloudId = updatedProduct.ImageCloudId;
            product.Price = updatedProduct.Price;
            product.Discount = updatedProduct.Discount;
            product.Specification = updatedProduct.Specification;

            return updatedProduct;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductByCategorys(string category)
        {
            var productsByCategory = await context.Products.Where(p => p.Category == category).ToListAsync();
            return productsByCategory;
        }

        public async Task<Product> ProductDetails(int id)
        {
            var product = await context.Products.FindAsync(id);
            return product;
        }
    }
}
