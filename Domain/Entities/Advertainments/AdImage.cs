using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.Advertainments
{
    public class AdImage : Entity
    {
        public int AdId { get; set; }
        public Advertainment Ad { get; set; }
        public string ImageUrl { get; set; }
        public string CloudinaryId { get; set; }
    }
}
