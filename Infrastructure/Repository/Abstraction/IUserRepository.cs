using Domain.Entities;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Infrastructure.Repository.Abstraction
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
}
