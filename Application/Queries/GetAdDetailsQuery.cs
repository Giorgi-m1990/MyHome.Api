using MediatR;
using MyHome.Application.Models.AdDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class GetAdDetailsQuery : IRequest<List<AdDetailsDto>>
    {
        public int AdId { get; set; }
        public GetAdDetailsQuery(int adId)
        {
            AdId = adId;
        }
    }
}
