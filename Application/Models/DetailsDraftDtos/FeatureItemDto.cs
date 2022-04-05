using Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models
{
    public class FeatureItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public bool IsActive { get; set; }
        public int FeatureId { get; set; }
        public List<FeatureItemSelectOptionDto> FeatureItemSelects { get; set; }
        public FeatureItemDto()
        {

        }
        public FeatureItemDto(FeatureItem featureItem)
        {
            Id = featureItem.Id;
            Name = featureItem.Name;
            FeatureType = featureItem.FeatureType;
            IsActive = featureItem.IsActive;
            FeatureId = featureItem.FeatureId;

            if(FeatureType == FeatureItemType.Select)
            {
                FeatureItemSelects = featureItem.FeatureItemSelects
                                                .Select(i => new FeatureItemSelectOptionDto(i))
                                                .ToList();
            }
        }
    }
}
