using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.ListenLogs.Commands.Delete
{
    public record DeleteListenLogCommandRequest(int Id) : IRequest<ListenLogDTO>;
    public class DeleteListenLogCommandHandler(IBaseRepository<ListenLog> _listenLogRepository) : IRequestHandler<DeleteListenLogCommandRequest, ListenLogDTO>
    {
        public async ValueTask<ListenLogDTO> Handle(DeleteListenLogCommandRequest request, CancellationToken cancellationToken)
        {
           ListenLog? deletedListenLog = await _listenLogRepository.DeleteAsync(request.Id);
            await _listenLogRepository.SaveAsync();
            return deletedListenLog.Adapt<ListenLogDTO>();
            
        }
    }
}
