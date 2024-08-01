using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Artists.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Artists.Commands.Delete
{
    public record DeleteArtistCommandRequest (int Id) : IRequest<ArtistDTO>;
    public class DeleteArtistCommandHandler(IBaseRepository<Artist> _artistRepository) : IRequestHandler<DeleteArtistCommandRequest, ArtistDTO>
    {
        public async ValueTask<ArtistDTO> Handle(DeleteArtistCommandRequest request, CancellationToken cancellationToken)
        {
            Artist? deletedArtist = await _artistRepository.DeleteAsync(request.Id);
            await _artistRepository.SaveAsync();
            return deletedArtist.Adapt<ArtistDTO>();


            throw new NotImplementedException();
        }
    }
}
