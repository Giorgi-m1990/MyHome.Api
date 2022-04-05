using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Abstraction
{
    public interface IFeatureItemSelectOptionsService
    {
        Task<bool> CreateFeatureItemSelectOption(FeatureItemSelectInputDto input);
    }
}
