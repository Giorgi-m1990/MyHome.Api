using MediatR;
using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class CreateAdFeaturesCommand : IRequest<bool>
    {
        public int AdId { get; set; }
        public List<CreateAdFeatureDto> AdFeatures { get; set; }
    }
}
