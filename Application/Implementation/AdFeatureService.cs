using Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Abstraction;
using MyHome.Application.Models;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Implementation
{
    public class AdFeatureService : IAdFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public AdFeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IEnumerable<FeatureDraftDto>> GetFeatureDraft()
        {
            var features = await _featureRepository.GetQueries(i => i.IsActive)
                                                   .Include(i => i.FeatureItems)
                                                   .ThenInclude(i => i.FeatureItemSelects)
                                                   .ToListAsync();

            return features?.Select(i => new FeatureDraftDto(i));
        }
    }
}
