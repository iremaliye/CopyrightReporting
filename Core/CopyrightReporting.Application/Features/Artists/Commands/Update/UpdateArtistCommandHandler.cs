using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Artists.Commands.Update
{
    public record UpdateArtistCommandRequest(int Id, string Name, bool isActive) : IRequest<ArtistDTO>;
    public class UpdateArtistCommandHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<UpdateArtistCommandRequest, ArtistDTO>
    {
        public async ValueTask<ArtistDTO> Handle(UpdateArtistCommandRequest request, CancellationToken cancellationToken)
        {
            Artist? updateEntity = await _artistRepository.UpdateAsync(request.Adapt<Artist>());
            await _artistRepository.SaveAsync();
            return updateEntity.Adapt<ArtistDTO>();
        }
    }
}
