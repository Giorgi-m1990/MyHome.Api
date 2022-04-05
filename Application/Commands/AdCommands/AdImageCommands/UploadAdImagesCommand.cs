using MediatR;
using Microsoft.AspNetCore.Http;
using MyHome.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class UploadAdImagesCommand : IRequest<bool>
    {
        public int AdId { get; set; }
        public List<string> Images { get; set; }
        public List<IFormFile> GetImageFiles()
        {
            try
            {
                var imageFiles = new List<IFormFile>();

                if (Images.Count == 0 || Images == null)
                    return default;

                foreach (var image in Images)
                {
                    imageFiles.Add(image.TestBase64());
                }
                return imageFiles;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
