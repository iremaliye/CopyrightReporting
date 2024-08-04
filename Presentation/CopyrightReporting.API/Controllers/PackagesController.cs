using CopyrightReporting.Application.Features.Packages.Commands.Create;
using CopyrightReporting.Application.Features.Packages.Commands.Delete;
using CopyrightReporting.Application.Features.Packages.Commands.Update;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Application.Features.Packages.Queries.GetAll;
using CopyrightReporting.Application.Features.Packages.Queries.GetById;
using CopyrightReporting.Application.Features.Providers.DTOs;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController(IMediator _mediator) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreatePackageCommandRequest createPackageCommandRequest)
        {
            PackageDTO? data = await _mediator.Send(createPackageCommandRequest);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAllPackagesQueryRequest getAllPackagesQueryRequest)
        {
            return Ok(await _mediator.Send(getAllPackagesQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdPackageQueryRequest getByIdPackageQueryRequest)
        {
            PackageDTO data = await _mediator.Send(getByIdPackageQueryRequest);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeletePackageCommandRequest deletePackageCommandRequest)
        {
            return Ok(await _mediator.Send(deletePackageCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePackageCommandRequest updatePackageCommandRequest)
        {
            return Ok(await _mediator.Send(updatePackageCommandRequest));
        }



    }
}
