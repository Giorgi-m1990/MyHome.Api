using CloudinaryDotNet.Actions;
using MediatR;
using MyHome.Application.Abstraction;
using MyHome.Domain.Entities.Advertainments;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class UploadAdImagesCommandHandler : IRequestHandler<UploadAdImagesCommand, bool>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAdImageRepository _adImageRepository;
        public UploadAdImagesCommandHandler(ICloudinaryService cloudinaryService, IAdImageRepository adImageRepository)
        {
            _adImageRepository = adImageRepository;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<bool> Handle(UploadAdImagesCommand request, CancellationToken cancellationToken)
        {
            List<Task<ImageUploadResult>> imageUploadsTasks = new List<Task<ImageUploadResult>>();

            foreach (var image in request.Images)
            {
                imageUploadsTasks.Add(_cloudinaryService.UploadImage(image));
            }
            

            var uploadImages = await Task.WhenAll(imageUploadsTasks);

            foreach (var image in uploadImages)
            {
                await _adImageRepository.Create(new AdImage()
                {
                    AdId = request.AdId,
                    CloudinaryId = image.PublicId,
                    ImageUrl = image.Url.AbsoluteUri
                });
            }

            return await _adImageRepository.SaveChangesAsync();
        }
    }
}
