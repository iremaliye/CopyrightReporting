

using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.ListenLogs.Commands.Create
{
    public record CreateListenLogCommandRequest(int MusicId,int PackageId,int Duration) : IRequest<ListenLogDTO>;
    public class CreateListenLogCommandHandle(IBaseRepository<ListenLog> _listenLogRepository) :
        IRequestHandler<CreateListenLogCommandRequest, ListenLogDTO>
    {
        public async ValueTask<ListenLogDTO> Handle(CreateListenLogCommandRequest request, CancellationToken cancellationToken)
        {
            ListenLog? listenLog = await _listenLogRepository.AddAsync(request.Adapt<ListenLog>());
            await _listenLogRepository.SaveAsync();
            return listenLog.Adapt<ListenLogDTO>();

        }
    }
}
