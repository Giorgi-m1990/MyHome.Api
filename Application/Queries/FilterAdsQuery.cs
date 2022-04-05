using MediatR;
using MyHome.Application.Models.AdDetails;
using MyHome.Application.Models.FilterDto;
using MyHome.Application.Models.GetAdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class FilterAdsQuery : IRequest<List<AdDetailsDto>>
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string Adress { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public string CadastralCode { get; set; }
        public List<FilteredAdFeatureItems> AdFeatureItems { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
