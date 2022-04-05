using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHome.Application.Abstraction;
using MyHome.Application.Commands;
using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRoleService _roleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(IMediator mediator, IRoleService roleService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mediator = mediator;
            _roleService = roleService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<string>> Authentication(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            var res = await _signInManager.PasswordSignInAsync(user, password, false, true);
            if (res.Succeeded)
            {
                var token = await _userManager.GenerateUserTokenAsync(user, "Default", "Login");
                return Ok(token);
            }
            else
                return Forbid();
        }

        [HttpPost("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand user)
        {
            return Ok(await _mediator.Send(user));
        }

        [HttpPost(nameof(PostRole))]
        public async Task<IActionResult> PostRole([FromForm]RoleTypeDto role)
        {
            var result = await _roleService.CreateRole(role);
            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(ChangeUserEmail))]
        public async Task<IActionResult> ChangeUserEmail(ChangeUserEmailCommand input)
        {
            var res = await _mediator.Send(input);
            if (res.Succeeded)
                return Ok();
            else
                return BadRequest();
        }
    }
}
