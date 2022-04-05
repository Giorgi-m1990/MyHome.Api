using Domain.Entities;
using Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Queries
{
    public class GetAdByUserQueryHandler : IRequestHandler<GetAdByUserQuery, List<GetAdsByUserNameDto>>
    {
        private readonly IAdRepository _adRepository;
        public GetAdByUserQueryHandler(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<List<GetAdsByUserNameDto>> Handle(GetAdByUserQuery request, CancellationToken cancellationToken)
        {
            var ads = _adRepository.GetQueries(i => i.User.Id == request.Id)
                                   .Skip((request.Page - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .OrderBy(i => i.CreationTime);

            if (ads == null)
                return default;

            
            return await ads.Select(i => new GetAdsByUserNameDto()
            {
                UserId = i.UserId,
                UserName = i.User.UserName,
                UserEmail = i.User.Email,
                UserPhone = i.User.PhoneNumber,
                Adress = i.Adress,
                Area = i.Area,
                CadastralCode = i.CadastralCode,
                Title = i.Title,
                Price = i.Price,
                CreationTime = i.CreationTime,
                Description = i.Description
            }).ToListAsync();
        }
    }
}
