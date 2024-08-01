using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.ListenLogs.Queries.GetById
{
    public record GetByIdListenLogQueryRequest(int Id) : IRequest<ListenLogDTO>;
    public class GetByIdListenLogQueryHandler(IBaseRepository<ListenLog> _listenLogRepository) : IRequestHandler<GetByIdListenLogQueryRequest, ListenLogDTO>
    {
        public async ValueTask<ListenLogDTO> Handle(GetByIdListenLogQueryRequest request, CancellationToken cancellationToken)
        {
            ListenLog? listenLog = await _listenLogRepository.GetAsync(request.Id);
            return listenLog.Adapt<ListenLogDTO>();
        }
    }
}
