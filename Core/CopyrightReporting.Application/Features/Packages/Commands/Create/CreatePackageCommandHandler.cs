using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Packages.Commands.Create
{
    public record CreatePackageCommandRequest (string Name, float Price, string Description) : IRequest<PackageDTO>;

    public class CreatePackageCommandHandler(IBaseRepository<Package> _packageRepository) : IRequestHandler<CreatePackageCommandRequest, PackageDTO>
    {
        public async ValueTask<PackageDTO> Handle(CreatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            Package? package = await _packageRepository.AddAsync(request.Adapt<Package>()) ;
            await _packageRepository.SaveAsync() ;
            return package.Adapt<PackageDTO>() ; 



        }
    }
}
