using CopyrightReporting.Application.Features.Providers.Commands.Create;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Application.Features.Providers.Queries.GetAll;
using CopyrightReporting.Application.Features.Providers.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateProviderCommandRequest createProviderCommandRequest)
        {
            ProviderDTO? data = await _mediator.Send(createProviderCommandRequest);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAllProvidersQueryRequest getAllProvidersQueryRequest)
        {
            return Ok(await _mediator.Send(getAllProvidersQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdProviderQueryRequest getByIdProviderQueryRequest)
        {
            ProviderDTO data = await _mediator.Send(getByIdProviderQueryRequest);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteProviderCommandRequest deleteProviderCommandRequest)
        {
            return Ok(await _mediator.Send(deleteProviderCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProviderCommandRequest updateProviderCommandRequest)
        {
            return Ok(await _mediator.Send(updateProviderCommandRequest));
        }

    }
}
