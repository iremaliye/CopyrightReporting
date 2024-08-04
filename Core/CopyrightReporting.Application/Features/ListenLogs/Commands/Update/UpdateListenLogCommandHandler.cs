using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.Commands.Create;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.ListenLogs.Commands.Update
{
    public record UpdateListenLogCommandRequest(int Id, int MusicId, int PackageId, int Duration, bool isActive): IRequest<ListenLogDTO>;
    public class UpdateListenLogCommandHandler(IBaseRepository<ListenLog> _listenLogRepository) : IRequestHandler<UpdateListenLogCommandRequest, ListenLogDTO>
    {
        public async ValueTask<ListenLogDTO> Handle(UpdateListenLogCommandRequest request, CancellationToken cancellationToken)
        {
            ListenLog? updateEntity = await _listenLogRepository.UpdateAsync(request.Adapt<ListenLog>());
            await _listenLogRepository.SaveAsync();
            return updateEntity.Adapt<ListenLogDTO>();
        }
    }
}
