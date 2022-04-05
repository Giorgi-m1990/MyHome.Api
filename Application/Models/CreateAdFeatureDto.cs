using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models
{
    public class CreateAdFeatureDto
    {
        public int AdvertainmentId { get; set; }
        public int FeatureItemId { get; set; }
        public string Content { get; set; }
        public bool? IsChecked { get; set; }
        public int? FeatureItemSelectId { get; set; }
    }
}
