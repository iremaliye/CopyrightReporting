using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Providers.Commands.Create
{
    public record DeleteProviderCommandRequest(int Id) : IRequest<ProviderDTO>;
    public class DeleteProviderCommandHandler(IBaseRepository<Provider> _providerRepository) : IRequestHandler<DeleteProviderCommandRequest, ProviderDTO>
    {
        public async ValueTask<ProviderDTO> Handle(DeleteProviderCommandRequest request, CancellationToken cancellationToken)
        {
            Provider? deletedProvider = await _providerRepository.DeleteAsync(request.Id);
            await _providerRepository.SaveAsync();
            return deletedProvider.Adapt<ProviderDTO>();
        }
    }
}
