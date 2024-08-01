using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.ListenLogs.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.ListenLogs.Queries.GetAll
{
    public record GetAllListenLogQueryRequest() : IRequest<List<ListenLogDTO>>;
    public class GetAllMusicQueryHandler(IBaseRepository<ListenLog> _listenLogRepository) : IRequestHandler<GetAllListenLogQueryRequest, List<ListenLogDTO>>
    {
        public async ValueTask<List<ListenLogDTO>> Handle(GetAllListenLogQueryRequest request, CancellationToken cancellationToken)
        {
            return await _listenLogRepository.GetAllAsync().Result.Where(ll => ll.IsActive).ProjectToType<ListenLogDTO>().ToListAsync();
        }
    }
}
