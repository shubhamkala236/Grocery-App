using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary cloudinary;
        public PhotoService(IConfiguration config)
        {
            Account account = new Account(
                config.GetSection("CloudinarySettings:CloudName").Value,
                config.GetSection("CloudinarySettings:CloudinaryAPIKey").Value,
                config.GetSection("CloudinarySettings:CloudinaryAPISecret").Value
                );

            cloudinary = new Cloudinary(account);
        }

        //delete
        public async Task<DeletionResult> DeletePhotoAsync(string cloudPhotoPublicId)
        {
            var deleteParams = new DeletionParams(cloudPhotoPublicId);

            var result = await cloudinary.DestroyAsync(deleteParams);

            return result;
        }
        //upload
        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if(photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(600)
                };

                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        //update
        public async Task<ImageUploadResult> UpdateImageAsync(string cloudPhotoPublicId, IFormFile newPhoto)
        {
            // Delete the old photo
            await DeletePhotoAsync(cloudPhotoPublicId);
            // Upload the new photo
            var uploadResult = await UploadPhotoAsync(newPhoto);

            return uploadResult;
        }

        ////find
        //public async Task<ImageDetails> FindPhotoAsync(string cloudPhotoPublicId)
        //{
        //    var getResourceParams = new GetResourceParams(cloudPhotoPublicId);
        //    var resourceResult = await _cloudinary.GetResourceAsync(getResourceParams);

        //    if (resourceResult.Error != null)
        //    {
        //        throw new Exception(resourceResult.Error.Message);
        //    }

        //    var imageDetails = new ImageDetails
        //    {
        //        PublicId = resourceResult.PublicId,
        //        Url = resourceResult.Url.ToString(),
        //        // Extract any other relevant information from resourceResult
        //    };

        //    return imageDetails;
        //}

    }
}
