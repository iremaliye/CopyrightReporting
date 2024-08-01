using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Providers.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Providers.Commands.Create
{
    public record UpdateProviderCommandRequest(int Id,string Email, string Name, bool IsActive) : IRequest<ProviderDTO>;
    public class UpdateProviderCommandHandler(IBaseRepository<Provider> _providerRepository) : IRequestHandler<UpdateProviderCommandRequest, ProviderDTO>
    {
        public async ValueTask<ProviderDTO> Handle(UpdateProviderCommandRequest request, CancellationToken cancellationToken)
        {
            Provider? updatedEntity = await _providerRepository.UpdateAsync(request.Adapt<Provider>());
            await _providerRepository.SaveAsync();
            return updatedEntity.Adapt<ProviderDTO>();
        }
    }
}
