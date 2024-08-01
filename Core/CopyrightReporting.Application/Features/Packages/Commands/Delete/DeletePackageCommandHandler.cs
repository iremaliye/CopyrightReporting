using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Packages.Commands.Delete
{
    public record DeletePackageCommandRequest(int Id): IRequest<PackageDTO>;
    public class DeletePackageCommandHandler(IBaseRepository<Package> _packageRepository) : IRequestHandler<DeletePackageCommandRequest, PackageDTO>
    {
        public async ValueTask<PackageDTO> Handle(DeletePackageCommandRequest request, CancellationToken cancellationToken)
        {
            Package? deletedPackage = await _packageRepository.DeleteAsync(request.Id);
            await _packageRepository.SaveAsync();
            return deletedPackage.Adapt<PackageDTO>();
        }
    }
}
