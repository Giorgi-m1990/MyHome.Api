using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class AdDraftController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFeatureItemSelectOptionsService _featureItemSelectService;
        private readonly IAdFeatureService _getAdDetailsService;
        public AdDraftController(IMediator mediator, IFeatureItemSelectOptionsService featureItemSelectService, IAdFeatureService getAdDetailsService)
        {
            _mediator = mediator;
            _featureItemSelectService = featureItemSelectService;
            _getAdDetailsService = getAdDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getAdDetailsService.GetFeatureDraft();
            if (result.Count() > 0)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost(nameof(PostFeatureItem))]
        public async Task<IActionResult> PostFeatureItem([FromForm]CreateFeatureItemCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(PostFeatureItemSelect))]
        public async Task<IActionResult> PostFeatureItemSelect(FeatureItemSelectInputDto input)
        {
            var result = await _featureItemSelectService.CreateFeatureItemSelectOption(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(PostFeature))]
        public async Task<IActionResult> PostFeature(CreateFeatureCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
