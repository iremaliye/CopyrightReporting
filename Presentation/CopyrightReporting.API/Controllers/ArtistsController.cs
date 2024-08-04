using CopyrightReporting.Application.Features.Artists.Commands.Create;
using CopyrightReporting.Application.Features.Artists.Commands.Delete;
using CopyrightReporting.Application.Features.Artists.Commands.Update;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Application.Features.Artists.Queries.GetAll;
using CopyrightReporting.Application.Features.Artists.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateArtistCommandRequest createArtistCommandRequest)
        {
            ArtistDTO? data = await _mediator.Send(createArtistCommandRequest);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAllArtistsQueryRequest getAllArtistsQueryRequest)
        {
            return Ok(await _mediator.Send(getAllArtistsQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdArtistQueryRequest getByIdArtistQueryRequest)
        {
            ArtistDTO data = await _mediator.Send(getByIdArtistQueryRequest);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteArtistCommandRequest deleteArtistCommandRequest)
        {
            return Ok(await _mediator.Send(deleteArtistCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateArtistCommandRequest updateArtistCommandRequest)
        {
            return Ok(await _mediator.Send(updateArtistCommandRequest));
        }
    }
}
