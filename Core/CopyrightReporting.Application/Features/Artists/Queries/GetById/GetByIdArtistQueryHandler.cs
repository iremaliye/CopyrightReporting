using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Artists.Queries.GetById
{
    public record GetByIdArtistQueryRequest(int Id) : IRequest<ArtistDTO>;
    public class GetByIdArtistQueryHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<GetByIdArtistQueryRequest, ArtistDTO>
    {
        public async ValueTask<ArtistDTO> Handle(GetByIdArtistQueryRequest request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.GetAsync(request.Id);
            return artist.Adapt<ArtistDTO>();
        }
    }
}
