using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.GetAdDtos
{
    public class FeatureItemDetailsDto
    {
        public int FeatureId { get; set; }
        public string FeatureItemName { get; set; }
        public string Content { get; set; }
        public bool? IsChecked { get; set; }
        public string FeatureItemSelectName { get; set; }
    }
}
