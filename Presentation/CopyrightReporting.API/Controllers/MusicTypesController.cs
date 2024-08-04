using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Application.Features.MusicTypes.Commands.Create;
using CopyrightReporting.Application.Features.MusicTypes.Queries.GetAll;
using CopyrightReporting.Application.Features.MusicTypes.Queries.GetById;
using CopyrightReporting.Application.Features.MusicTypes.Commands.Delete;
using CopyrightReporting.Application.Features.MusicTypes.Commands.Update;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MusicTypesController(IMediator _mediator): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateMusicTypeCommandRequest createMusicTypeCommandRequest)
        {
            MusicTypeDTO? data = await _mediator.Send(createMusicTypeCommandRequest);
            return Ok(data);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllAsync([FromRoute] GetAllMusicTypesQueryRequest getAllMusicTypesQueryRequest)
        {
            return Ok(await _mediator.Send(getAllMusicTypesQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdMusicTypeQueryRequest getByIdMusicTypeQueryRequest)
        {
            MusicTypeDTO data = await _mediator.Send(getByIdMusicTypeQueryRequest);
            return Ok(data);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteMusicTypeCommandRequest deletemusicTypeCommandRequest)
        {
            return Ok(await _mediator.Send(deletemusicTypeCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateMusicTypeCommandRequest updateMusicTypeCommandRequest)
        {
            return Ok(await _mediator.Send(updateMusicTypeCommandRequest));
        }

    }
}
