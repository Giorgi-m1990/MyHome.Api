using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
