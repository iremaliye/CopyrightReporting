
using CopyrightReporting.Application.Features.Musics.Commands.Create;
using CopyrightReporting.Application.Features.Musics.Commands.Delete;
using CopyrightReporting.Application.Features.Musics.Commands.Update;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Application.Features.Musics.Queries.GetAll;
using CopyrightReporting.Application.Features.Musics.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateMusicCommandRequest createMusicCommandRequest)
        {
            MusicDTO? data = await _mediator.Send(createMusicCommandRequest);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAllMusicsQueryRequest getAllMusicsQueryRequest)
        {
            
            return Ok(await _mediator.Send(getAllMusicsQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdMusicQueryRequest getByIdMusicQueryRequest)
        {
            MusicDTO data = await _mediator.Send(getByIdMusicQueryRequest);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteMusicCommandRequest deleteMusicCommandRequest)
        {
            return Ok(await _mediator.Send(deleteMusicCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateMusicCommandRequest updateMusicCommandRequest)
        {
            return Ok(await _mediator.Send(updateMusicCommandRequest));
        }
    }
}
