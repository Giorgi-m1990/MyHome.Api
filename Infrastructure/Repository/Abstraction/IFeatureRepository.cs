using Domain.Entities;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Abstraction
{
    public interface IFeatureRepository : IRepository<Feature>
    {
    }
}
