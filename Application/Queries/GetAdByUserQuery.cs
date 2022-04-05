using Domain.Entities;
using MediatR;
using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class GetAdByUserQuery : IRequest<List<GetAdsByUserNameDto>>
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public GetAdByUserQuery(int id, int page, int pageSize)
        {
            Id = id;
            Page = page;
            PageSize = pageSize;
        }
    }
}
