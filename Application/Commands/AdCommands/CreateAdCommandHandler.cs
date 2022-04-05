using Domain.Entities;
using Infrastructure.Repository.Abstraction;
using MediatR;
using MyHome.Application.Commands;
using MyHome.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand, bool>
    {
        private readonly IAdRepository _adRepository;
        private readonly IMediator _mediator;
        public CreateAdCommandHandler(IAdRepository adRepository,IMediator mediator)
        {
            _adRepository = adRepository;
            _mediator = mediator;
        }
        public async Task<bool> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var ad = new Advertainment()
            {
                Price = request.Price,
                CreationTime = request.CreationTime,
                Adress = request.Adress,
                Area = request.Area,
                CadastralCode = request.CadastralCode,
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId,
                AdStatus = AdStatus.Active
            };
            await _adRepository.Create(ad);
            

            if(request.Images != null)
            {
                var imageUploadCommand = new UploadAdImagesCommand() { AdId = ad.Id, Images = request.Images };
                await _mediator.Send(imageUploadCommand);
            }

            var adResult = await _adRepository.SaveChangesAsync();

            if (adResult)
                return true;
            else
                return false;
        }
    }
}
