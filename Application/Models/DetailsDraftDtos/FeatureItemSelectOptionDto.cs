using MyHome.Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models
{
    public class FeatureItemSelectOptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FeatureItemId { get; set; }
        public FeatureItemSelectOptionDto()
        {

        }
        public FeatureItemSelectOptionDto(FeatureItemSelect featureItemSelect)
        {
            Id = featureItemSelect.Id;
            Name = featureItemSelect.Name;
            FeatureItemId = featureItemSelect.FeatureItemId;
        }
    }
}
