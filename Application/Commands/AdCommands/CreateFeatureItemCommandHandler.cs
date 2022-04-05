using Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateFeatureItemCommandHandler : IRequestHandler<CreateFeatureItemCommand, bool>
    {
        private readonly IFeatureItemRepository _featureItemRepository;
        public CreateFeatureItemCommandHandler(IFeatureItemRepository featureItemRepository)
        {
            _featureItemRepository = featureItemRepository;
        }
        public async Task<bool> Handle(CreateFeatureItemCommand request, CancellationToken cancellationToken)
        {
            await _featureItemRepository.Create(new Domain.Entities.Advertainments.FeatureItem()
            {
                Name = request.Name,
                IsActive = request.IsActive,
                FeatureType = request.FeatureType,
                FeatureId = request.FeatureId
            });
            return await _featureItemRepository.SaveChangesAsync();
        }
    }
}
