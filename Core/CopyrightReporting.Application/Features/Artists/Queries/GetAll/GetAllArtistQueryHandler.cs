using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Artists.Queries.GetAll
{
    public record GetAllArtistsQueryRequest() : IRequest<List<ArtistDTO>>;
    public class GetAllArtistsQueryHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<GetAllArtistsQueryRequest, List<ArtistDTO>>
    {
  
        public async ValueTask<List<ArtistDTO>> Handle(GetAllArtistsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _artistRepository.GetAllAsync().Result.Where(a => a.IsActive).ProjectToType<ArtistDTO>().ToListAsync();
        }
    }
}
