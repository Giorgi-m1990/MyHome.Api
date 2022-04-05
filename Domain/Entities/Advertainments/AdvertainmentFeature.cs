using MyHome.Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Advertainments
{
    public class AdvertainmentFeature : Entity
    {
        public int AdvertainmentId { get; set; }
        public Advertainment Advertainment { get; set; }
        public int FeatureItemId { get; set; }
        public FeatureItem FeatureItem { get; set; }
        public string Content { get; set; }
        public bool? IsChecked { get; set; }
        public int? FeatureItemSelectId { get; set; }
    }
}
