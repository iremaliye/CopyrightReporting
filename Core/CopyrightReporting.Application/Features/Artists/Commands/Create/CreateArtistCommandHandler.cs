using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Artists.Commands.Create
{
    public record CreateArtistCommandRequest(string Name) : IRequest<ArtistDTO>;
    public class CreateArtistCommandHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<CreateArtistCommandRequest, ArtistDTO>
    {
        public async ValueTask<ArtistDTO> Handle(CreateArtistCommandRequest request, CancellationToken cancellationToken)
        {
            Artist? artist = await _artistRepository.AddAsync(request.Adapt<Artist>());
            await _artistRepository.SaveAsync();
            return  artist.Adapt<ArtistDTO>();
        }
    }
}
