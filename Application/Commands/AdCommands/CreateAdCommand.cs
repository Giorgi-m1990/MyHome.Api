using Domain.Entities.Advertainments;
using MediatR;
using MyHome.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateAdCommand : IRequest<bool>
    {
        public int Price { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }
        public string CadastralCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<string> Images { get; set; }
    }
}
