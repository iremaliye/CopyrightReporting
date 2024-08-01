using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Artists.Queries.GetAll
{
    public record GetAllArtistQueryRequest() : IRequest<List<ArtistDTO>>;
    public class GetAllMusicQueryHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<GetAllArtistQueryRequest, List<ArtistDTO>>
    {
  
        public async ValueTask<List<ArtistDTO>> Handle(GetAllArtistQueryRequest request, CancellationToken cancellationToken)
        {
            return await _artistRepository.GetAllAsync().Result.Where(a => a.IsActive).ProjectToType<ArtistDTO>().ToListAsync();
        }
    }
}
