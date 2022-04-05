using Domain.Entities.Advertainments;
using MyHome.Domain.Constants;
using MyHome.Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Advertainment : Entity
    {
        public int Price { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }
        public string CadastralCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public AdStatus AdStatus { get; set; }
        public AppUser User { get; set; }
        public ICollection<AdvertainmentFeature> AdvertainmentFeatures { get; set; }
        public ICollection<AdImage> Images { get; set; }
    }
}
