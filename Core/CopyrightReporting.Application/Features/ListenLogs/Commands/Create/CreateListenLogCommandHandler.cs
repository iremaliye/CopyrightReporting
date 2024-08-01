

using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.ListenLogs.Commands.Create
{
    public record CreateListenLogRequest(int MusicId,int PackageId,DateTime Duration) : IRequest<ListenLogDTO>;
    public class CreateListenLogCommandHandle(IBaseRepository<ListenLog> _listenLogRepository) :
        IRequestHandler<CreateListenLogRequest, ListenLogDTO>
    {
        public async ValueTask<ListenLogDTO> Handle(CreateListenLogRequest request, CancellationToken cancellationToken)
        {
            ListenLog? listenLog = await _listenLogRepository.AddAsync(request.Adapt<ListenLog>());
            await _listenLogRepository.SaveAsync();
            return listenLog.Adapt<ListenLogDTO>();

        }
    }
}
