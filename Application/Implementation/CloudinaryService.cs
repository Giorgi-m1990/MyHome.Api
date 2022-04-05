using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MyHome.Application.Abstraction;
using MyHome.Application.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySetting> cloudinarySetting)
        {
            var setting = cloudinarySetting.Value;
            var account = new Account() { Cloud = setting.Cloud, ApiKey = setting.ApiKey, ApiSecret = setting.ApiSecret };
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile file)
        {
            var result = new ImageUploadResult();
            
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams() { File = new FileDescription(file.FileName, stream) };
                result = await _cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }

        public async Task<ImageUploadResult> UploadImage(string base64string)
        {
            var result = new ImageUploadResult();

            if (base64string.Length > 0)
            {
                Byte[] bytes = Convert.FromBase64String(base64string);
                using var stream = new MemoryStream(bytes);
                var uploadParams = new ImageUploadParams() { File = new FileDescription(Guid.NewGuid().ToString(), stream) };
                result = await _cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }

        public async Task<DeletionResult> DeleteImage(string publicId)
        {
            var result = await _cloudinary.DestroyAsync(new DeletionParams(publicId));

            return result;
        }
    }
}
