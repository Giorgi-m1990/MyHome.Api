using Domain.Entities.Advertainments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateFeatureItemCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public bool IsActive { get; set; }
        public int FeatureId { get; set; }
    }
}
