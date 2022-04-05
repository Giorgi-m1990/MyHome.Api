using Domain.Entities.Advertainments;
using Infrastructure.DataContext;
using Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
    public class FeatureItemRepository : Repository<FeatureItem>, IFeatureItemRepository
    {
        public FeatureItemRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
