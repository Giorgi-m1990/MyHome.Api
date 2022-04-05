using Infrastructure.DataContext;
using Infrastructure.Repository.Implementation;
using MyHome.Domain.Entities.Advertainments;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Infrastructure.Repository.Implementation
{
    public class FeatureItemSelectRepository : Repository<FeatureItemSelect>, IFeatureItemSelectRepository
    {
        public FeatureItemSelectRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
