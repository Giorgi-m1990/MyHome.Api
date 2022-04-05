using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyHome.Domain.Constants;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            var userName = await _userManager.FindByNameAsync(request.UserName);

            if (userEmail == null && userName == null)
            {
                var newUser = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    PhoneNumber = request.Phone
                };

                var userCreated = await _userManager.CreateAsync(newUser, request.Password);

                var userClaims = new List<Claim>();
                userClaims.Add(new Claim("id", newUser.Id.ToString()));
                userClaims.Add(new Claim("email", newUser.Email));
                userClaims.Add(new Claim("phone", newUser.PhoneNumber));

                await _userManager.AddClaimsAsync(newUser, userClaims);

                var token = await _userManager.GenerateUserTokenAsync(newUser, "Default", "Login");

                if (userCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, RoleType.User.ToString());
                    return token;
                }
                else
                    return IdentityResult.Failed().ToString();
            }
            else
                return IdentityResult.Failed(new IdentityError() { Description = "Username or Email is Already in use!" }).ToString();
        }
    }
}
