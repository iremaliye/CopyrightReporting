
using CopyrightReporting.Application.Features.ListenLogs.Commands.Create;
using CopyrightReporting.Application.Features.ListenLogs.Commands.Delete;
using CopyrightReporting.Application.Features.ListenLogs.Commands.Update;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Application.Features.ListenLogs.Queries.GetAll;
using CopyrightReporting.Application.Features.ListenLogs.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenLogsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateListenLogCommandRequest createListenLogCommandRequest)
        {
            ListenLogDTO? data = await _mediator.Send(createListenLogCommandRequest);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromRoute] GetAllListenLogsQueryRequest getAllListenLogsQueryRequest)
        {
            return Ok(await _mediator.Send(getAllListenLogsQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetByIdListenLogQueryRequest getByIdListenLogQueryRequest)
        {
            ListenLogDTO data = await _mediator.Send(getByIdListenLogQueryRequest);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteListenLogCommandRequest deleteListenLogCommandRequest)
        {
            return Ok(await _mediator.Send(deleteListenLogCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateListenLogCommandRequest updateListenLogCommandRequest)
        {
            return Ok(await _mediator.Send(updateListenLogCommandRequest));
        }

    }
}
