using Domain.Entities;
using Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.GetAdDtos
{
    public class GetAdDto
    {
        public int Price { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }
        public string CadastralCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<AdvertainmentFeature> AdvertainmentFeatures { get; set; }
    }
}
