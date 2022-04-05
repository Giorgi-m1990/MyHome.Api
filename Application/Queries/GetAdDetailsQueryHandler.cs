using Domain.Entities.Advertainments;
using Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.AdDetails;
using MyHome.Application.Models.GetAdDtos;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class GetAdDetailsQueryHandler : IRequestHandler<GetAdDetailsQuery, List<AdDetailsDto>>
    {
        private readonly IAdRepository _adRepository;
        private readonly IFeatureRepository _featureRepository;
        public GetAdDetailsQueryHandler(IAdRepository adRepository, IFeatureRepository featureRepository)
        {
            _adRepository = adRepository;
            _featureRepository = featureRepository;
        }
        public async Task<List<AdDetailsDto>> Handle(GetAdDetailsQuery request, CancellationToken cancellationToken)
        {
            var advertainment = await _adRepository.GetQueries(i => i.Id == request.AdId)
                                               .Include(i => i.User)
                                               .Include(i => i.AdvertainmentFeatures)
                                               .ThenInclude(i => i.FeatureItem)
                                               .ThenInclude(i => i.Feature)
                                               .Include(i => i.AdvertainmentFeatures)
                                               .ThenInclude(i => i.FeatureItem)
                                               .ThenInclude(i => i.FeatureItemSelects)
                                               .SingleOrDefaultAsync();


            var adList = new List<AdDetailsDto>();
            var features = await _featureRepository.GetCollectionAsync(i => i.IsActive);

            adList.Add(new AdDetailsDto()
            {
                Adress = advertainment.Adress,
                Area = advertainment.Area,
                CadastralCode = advertainment.CadastralCode,
                CreationTime = advertainment.CreationTime,
                Description = advertainment.Description,
                Title = advertainment.Title,
                Price = advertainment.Price,
                UserId = advertainment.UserId,
                UserName = advertainment.User.UserName,
                UserEmail = advertainment.User.Email,
                UserPhone = advertainment.User.PhoneNumber,
                Features = features.Select(f => new FeatureDto()
                {
                    Id = f.Id,
                    FeatureName = f.Name,
                    FeatureItems = advertainment.AdvertainmentFeatures
                                               .GroupBy(g => g.FeatureItem.FeatureId)
                                               .SingleOrDefault(j => j.Key == f.Id)
                                               .Select(i => new FeatureItemDetailsDto()
                                               {
                                                   FeatureId = f.Id,
                                                   Content = i.Content,
                                                   FeatureItemName = i.FeatureItem.Name,
                                                   FeatureItemSelectName = i.FeatureItem
                                                                            .FeatureItemSelects
                                                                            .Select(i => i.Name)
                                                                            .FirstOrDefault(),
                                                   IsChecked = i.IsChecked
                                               }).ToList()
                }).ToList()
            });

            return adList;
        }
    }
}
