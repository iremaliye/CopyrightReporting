using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Packages.Queries.GetAll
{
    public record GetAllPackagesQueryRequest() : IRequest<List<PackageDTO>>;
    public class GetAllProvidersQueryHandler(IBaseRepository<Package> _packageRepository) : IRequestHandler<GetAllPackagesQueryRequest, List<PackageDTO>>
    {
        public async ValueTask<List<PackageDTO>> Handle(GetAllPackagesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _packageRepository.GetAllAsync().Result.Where(p => p.IsActive).ProjectToType<PackageDTO>().ToListAsync();
        }
    }
}
