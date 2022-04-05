using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.FilterDto
{
    public class FilteredAdsFeature
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public List<FilteredAdFeatureItems> FeatureItems { get; set; }
    }
}
