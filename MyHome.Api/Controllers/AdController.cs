using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.Application.Commands;
using MyHome.Application.Models;
using MyHome.Application.Models.AdDetails;
using MyHome.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IMediator _mediator;
        const int maxPageSize = 20;
        public AdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/{userId}/{pageSize}/{pageNum}")]
        public async Task<ActionResult<GetAdsByUserNameDto>> Get(int userId,
            int pageNum = 1,
            int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;
            return Ok(await _mediator.Send(new GetAdByUserQuery(userId, pageNum, pageSize)));
        }

        [HttpGet("/{adId}")]
        public async Task<ActionResult<AdDetailsDto>> GetDetails(int adId)
        {
            var result = await _mediator.Send(new GetAdDetailsQuery(adId));

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        //[HttpPost(nameof(FilterAds))]
        //public async Task<IActionResult> FilterAds([FromForm] FilterAdsQuery input)
        //{
        //    var result = await _mediator.Send(input);
        //    if (result != null)
        //        return Ok(result);
        //    else
        //        return BadRequest(result);
        //}

        [HttpPost]
        public async Task<ActionResult> Post(CreateAdCommand input)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(i => i.Type == "id").Value;
                input.UserId = Convert.ToInt32(userId);
                var result = await _mediator.Send(input);
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
                return Forbid();
        }

        [HttpPost(nameof(SaveAdFeatures))]
        public async Task<IActionResult> SaveAdFeatures(CreateAdFeaturesCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(PostImages))]
        public async Task<IActionResult> PostImages(UploadAdImagesCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
