using MyHome.Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Advertainments
{
    public class FeatureItem : Entity
    {
        public string Name { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public bool IsActive { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public ICollection<AdvertainmentFeature> AdvertainmentFeatures { get; set; }
        public ICollection<FeatureItemSelect> FeatureItemSelects { get; set; }
    }
}
