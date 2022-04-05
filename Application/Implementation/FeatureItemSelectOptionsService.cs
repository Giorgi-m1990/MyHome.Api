using Microsoft.EntityFrameworkCore;
using MyHome.Application.Abstraction;
using MyHome.Application.Models;
using MyHome.Domain.Entities.Advertainments;
using MyHome.Infrastructure.Repository.Abstraction;
using MyHome.Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Implementation
{
    public class FeatureItemSelectOptionsService : IFeatureItemSelectOptionsService
    {
        private readonly IFeatureItemSelectRepository _featureItemSelectRepository;
        public FeatureItemSelectOptionsService(IFeatureItemSelectRepository featureItemSelectRepository)
        {
            _featureItemSelectRepository = featureItemSelectRepository;
        }

        public async Task<bool> CreateFeatureItemSelectOption(FeatureItemSelectInputDto input)
        {
            var selectItem = await _featureItemSelectRepository
                                    .GetQueries(i => i.Name.Trim().ToLower() == input.Name.Trim().ToLower())
                                    .SingleOrDefaultAsync();
            if (selectItem == null)
            {
                await _featureItemSelectRepository.Create(new FeatureItemSelect()
                {
                    Name = input.Name,
                    FeatureItemId = input.FeatureItemId
                });

                return await _featureItemSelectRepository.SaveChangesAsync();
            }
            else
                return false;
        }
    }
}
