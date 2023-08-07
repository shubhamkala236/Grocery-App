using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ProductBLL : IProductsBLL
    {
        private readonly IUnitOfWork uow;
        private readonly IPhotoService photoService;

        public ProductBLL(IUnitOfWork uow,IPhotoService photoService)
        {
            this.uow = uow;
            this.photoService = photoService;
        }
        public async Task<bool> AddProduct(AddProductDto product)
        {
            //convert productdto to product and send to repository to perform add
            //add photo to cloudinary

            var uploadPhoto = await photoService.UploadPhotoAsync(product.ImageFile);
            var imageUrl = uploadPhoto.SecureUrl;

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Category = product.Category,
                Quantity = product.Quantity,
                ImageUrl = imageUrl.ToString(),
                ImageCloudId = uploadPhoto.PublicId,
                Price = product.Price,
                Discount = product.Discount,
                Specification = product.Specification,
            };

            var result = await uow.ProductRepository.AddProduct(newProduct);
            await uow.SaveAsync();
            return result;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var result = await uow.ProductRepository.DeleteProduct(productId);
            var cloudinaryId = result.ImageCloudId;
            if(cloudinaryId!=null)
            {
                await photoService.DeletePhotoAsync(cloudinaryId);
            }
            await uow.SaveAsync();
            return result;
        }

        //Get all products
        public async Task<IEnumerable<DisplayProductDto>> GetAllProducts()
        {
            var result = await uow.ProductRepository.GetAllProducts();
            var productDto = result.Select(p => new DisplayProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Category = p.Category,
                Quantity = p.Quantity,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Discount = p.Discount,
                Specification = p.Specification,
            }).ToList();

            return productDto;
        }

        //get products based on category
        public async Task<IEnumerable<DisplayProductDto>> GetProductByCategory(string category)
        {
            var result = await uow.ProductRepository.GetProductByCategorys(category);
            var productDto = result.Select(p => new DisplayProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Category = p.Category,
                Quantity = p.Quantity,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Discount = p.Discount,
                Specification = p.Specification,
            }).ToList();

            return productDto;
        }

        //Product Details
        public async Task<DisplayProductDto> ProductDetails(int id)
        {
            var result = await uow.ProductRepository.ProductDetails(id);
            if(result==null)
            {
                return null;
            }
            //return a displayProductDto
            var productDto = new DisplayProductDto
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                Description = result.Description,
                Category = result.Category,
                Quantity = result.Quantity,
                ImageUrl = result.ImageUrl,
                Price = result.Price,
                Discount = result.Discount,
                Specification = result.Specification,
            };

            return productDto;
        }

        public async Task<DisplayProductDto> UpdateProduct(int productId,AddProductDto product)
        {
            //every time just upload to cloudinary 
            var newPhoto = await photoService.UploadPhotoAsync(product.ImageFile); 
            //product.ImageFile
            //productdto ---> product
            var newProduct = new Product
            {
                ProductId = productId,
                ProductName = product.ProductName,
                Description = product.Description,
                Category = product.Category,
                Quantity = product.Quantity,
                ImageUrl = newPhoto.SecureUrl.ToString(),
                ImageCloudId = newPhoto.PublicId,
                Price = product.Price,
                Discount = product.Discount,
                Specification = product.Specification,
            };

            var result = await uow.ProductRepository.EditProduct(productId,newProduct);
            await uow.SaveAsync();

            var productDto = new DisplayProductDto
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                Description = result.Description,
                Category = result.Category,
                Quantity = result.Quantity,
                ImageUrl = result.ImageUrl,
                Price = result.Price,
                Discount = result.Discount,
                Specification = result.Specification,
            };

            return productDto;
        }
    }
}
