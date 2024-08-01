using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Providers.Commands.Create
{
    public record CreateProviderCommandRequest(string Email, string Name) : IRequest<ProviderDTO>;
    public class CreateProviderCommandHandler(IBaseRepository<Provider> _providerRepository) : IRequestHandler<CreateProviderCommandRequest, ProviderDTO>
    {
        public async ValueTask<ProviderDTO> Handle(CreateProviderCommandRequest request, CancellationToken cancellationToken)
        {
            Provider? provider = await _providerRepository.AddAsync(request.Adapt<Provider>());
            await _providerRepository.SaveAsync();
            return provider.Adapt<ProviderDTO>();
        }
    }
}
