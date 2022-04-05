using Domain.Entities.Advertainments;
using Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class CreateAdFeaturesCommandHandler : IRequestHandler<CreateAdFeaturesCommand, bool>
    {
        private readonly IAdRepository _adRepository;
        public CreateAdFeaturesCommandHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<bool> Handle(CreateAdFeaturesCommand request, CancellationToken cancellationToken)
        {
            var ad = await _adRepository.GetQueries(i => i.Id == request.AdId)
                                        .Include(i => i.AdvertainmentFeatures)
                                        .SingleOrDefaultAsync();

            if (ad == null)
                return default;

            for (int s = 0; s < request.AdFeatures.Count; s++)
            {
                if (ad.AdvertainmentFeatures.Any(i => i.FeatureItemId == request.AdFeatures[s].FeatureItemId))
                {
                    var featureItem = ad.AdvertainmentFeatures.Where(i => i.FeatureItemId == request.AdFeatures[s].FeatureItemId).SingleOrDefault();
                    featureItem.Content = request.AdFeatures[s].Content;
                    featureItem.IsChecked = request.AdFeatures[s].IsChecked;
                    featureItem.FeatureItemSelectId = request.AdFeatures[s].FeatureItemSelectId;
                }
                else
                {
                    ad.AdvertainmentFeatures.Add(new AdvertainmentFeature()
                    {
                        AdvertainmentId = request.AdFeatures[s].AdvertainmentId,
                        FeatureItemId = request.AdFeatures[s].FeatureItemId,
                        Content = request.AdFeatures[s].Content,
                        FeatureItemSelectId = request.AdFeatures[s].FeatureItemSelectId,
                        IsChecked = request.AdFeatures[s].IsChecked
                    });
                }
            }

            _adRepository.Update(ad);
            return await _adRepository.SaveChangesAsync();
        }
    }
}
