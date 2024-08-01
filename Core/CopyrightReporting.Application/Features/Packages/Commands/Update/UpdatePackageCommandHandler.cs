using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Packages.Commands.Update
{
    public record UpdatePackageCommandRequest (int Id, string Name, float Price, string Description, bool isActive) : IRequest<PackageDTO>;
    public class UpdatePackageCommandHandler(IBaseRepository<Package> _packageRepository) : IRequestHandler<UpdatePackageCommandRequest, PackageDTO>
    {
        public async ValueTask<PackageDTO> Handle(UpdatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            Package? updatedEntity = await _packageRepository.UpdateAsync(request.Adapt <Package>());
            await _packageRepository.SaveAsync();
            return updatedEntity.Adapt<PackageDTO>();

        }
    }
}
