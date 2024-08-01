using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Providers.Queries.GetById
{
    public record GetByIdProviderQueryRequest(int Id) : IRequest<ProviderDTO>;
    public class GetByIdProviderQueryHandler(IBaseRepository<Provider> _providerRepository) : IRequestHandler<GetByIdProviderQueryRequest, ProviderDTO>
    {
        public async ValueTask<ProviderDTO> Handle(GetByIdProviderQueryRequest request, CancellationToken cancellationToken)
        {
            Provider? provider = await _providerRepository.GetAsync(request.Id);
            return provider.Adapt<ProviderDTO>();
        }
    }
}
