using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Packages.Queries.GetById
{
        public record GetByIdProviderQueryRequest(int Id) : IRequest<PackageDTO>;
        public class GetByIdProviderQueryHandler(IBaseRepository<Package> _providerRepository) : IRequestHandler<GetByIdProviderQueryRequest, PackageDTO>
        {
            public async ValueTask<PackageDTO> Handle(GetByIdProviderQueryRequest request, CancellationToken cancellationToken)
            {
            Package? package = await _providerRepository.GetAsync(request.Id);
                return package.Adapt<PackageDTO>();
            }
        }
}
