using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Packages.Queries.GetById
{
        public record GetByIdPackageQueryRequest(int Id) : IRequest<PackageDTO>;
        public class GetByIdPackageQueryHandler(IBaseRepository<Package> _packageRepository) : IRequestHandler<GetByIdPackageQueryRequest, PackageDTO>
        {
        

        public async ValueTask<PackageDTO> Handle(GetByIdPackageQueryRequest request, CancellationToken cancellationToken)
        {
            Package? package = await _packageRepository.GetAsync(request.Id);
            return package.Adapt<PackageDTO>();
        }
    }
}
