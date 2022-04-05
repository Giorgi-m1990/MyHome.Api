using Microsoft.AspNetCore.Identity;
using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Abstraction
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRole(RoleTypeDto input);
    }
}
