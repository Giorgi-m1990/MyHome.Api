using Domain.Entities.Advertainments;
using Infrastructure.DataContext;
using Infrastructure.Repository.Abstraction;
using Infrastructure.Repository.Implementation;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Infrastructure.Repository.Implementation
{
    public class AdvertainmentFeatureRepository : Repository<AdvertainmentFeature>, IAdvertainmentFeatureRepository
    {
        public AdvertainmentFeatureRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
