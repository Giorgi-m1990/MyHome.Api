using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class ChangeUserEmailCommand : IRequest<IdentityResult>
    {
        public string UserName { get; set; }
        public string NewEmail { get; set; }
    }
}
