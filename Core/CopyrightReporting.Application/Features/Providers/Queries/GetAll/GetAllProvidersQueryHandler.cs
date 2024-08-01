using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Providers.Queries.GetAll
{
    public record GetAllProvidersQueryRequest() : IRequest<List<ProviderDTO>>;
    public class GetAllProvidersQueryHandler(IBaseRepository<Provider> _providerRepository) : IRequestHandler<GetAllProvidersQueryRequest, List<ProviderDTO>>
    {
        public async ValueTask<List<ProviderDTO>> Handle(GetAllProvidersQueryRequest request, CancellationToken cancellationToken)
        {
            return await _providerRepository.GetAllAsync().Result.Where(p => p.IsActive).ProjectToType<ProviderDTO>().ToListAsync();
        }
    }
}
