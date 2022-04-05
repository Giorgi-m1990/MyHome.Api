using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class ChangeUserEmailCommandHandler : IRequestHandler<ChangeUserEmailCommand, IdentityResult>
    {
        private readonly UserManager<AppUser> _userManager;
        public ChangeUserEmailCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return IdentityResult.Failed();

            var token = await _userManager.GenerateChangeEmailTokenAsync(user, request.NewEmail);

            var result = await _userManager.ChangeEmailAsync(user, request.NewEmail, token);

            return result;
        }
    }
}
