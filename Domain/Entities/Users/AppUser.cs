using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<Advertainment> Advertainments { get; set; }
    }
}
