using Domain.Entities.Advertainments;
using Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.AdDetails;
using MyHome.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class FilterAdsQueryHandler : IRequestHandler<FilterAdsQuery, List<AdDetailsDto>>
    {
        private readonly IAdRepository _adRepository;
        public FilterAdsQueryHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public async Task<List<AdDetailsDto>> Handle(FilterAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = _adRepository.GetQueries(i => i.AdStatus == AdStatus.Active)
                                   .Include(i => i.AdvertainmentFeatures)
                                   .ThenInclude(i => i.FeatureItem)
                                   .AsQueryable();

            if (request.MinPrice != null)
                ads = ads.Where(i => i.Price >= request.MinPrice);

            if (request.MaxPrice != null)
                ads = ads.Where(i => i.Price <= request.MaxPrice);


            if (request.MinArea != null && request.MaxArea == null)
                ads = ads.Where(i => i.Area > request.MinArea);

            if (request.MinArea != null && request.MaxArea != null)
                ads = ads.Where(i => i.Area > request.MinArea && i.Area < request.MaxArea);

            if (request.MinArea == null && request.MaxArea != null)
                ads = ads.Where(i => i.Area < request.MaxArea);

            if (!string.IsNullOrEmpty(request.CadastralCode))
                ads = ads.Where(i => i.CadastralCode.Contains(request.CadastralCode));

            if (!string.IsNullOrEmpty(request.Adress))
                ads = ads.Where(i => i.Adress.ToLower().Contains(request.Adress.ToLower()));

            foreach (var featureItem in request.AdFeatureItems)
            {
                ads = ads.Where(i => i.AdvertainmentFeatures
                                .Any(o => o.FeatureItemId == featureItem.Id
                                          && ((o.FeatureItem.FeatureType == FeatureItemType.Text
                                              && !string.IsNullOrEmpty(o.Content)) ||
                                              (o.FeatureItem.FeatureType == FeatureItemType.Check
                                              && o.IsChecked == featureItem.IsChecked) ||
                                              (o.FeatureItem.FeatureType == FeatureItemType.Select
                                              && o.FeatureItemSelectId == featureItem.FeatureItemSelectId))));
            }
            
            return await ads.Select(i => new AdDetailsDto() 
            {
                 Adress = i.Adress,
                 Area = i.Area,
                 Price = i.Price,
                 CadastralCode = i.CadastralCode,
                 CreationTime = i.CreationTime,
                 Description = i.Description,
                 UserId= i.UserId,
                 UserName = i.User.UserName,
                 UserEmail = i.User.Email,
                 UserPhone = i.User.PhoneNumber
            })
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        }
    }
}
