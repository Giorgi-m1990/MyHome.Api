using Domain;
using Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.Advertainments
{
    public class FeatureItemSelect : Entity
    {
        public string Name { get; set; }
        public int FeatureItemId { get; set; }
        public FeatureItem FeatureItem { get; set; }
    }
}
