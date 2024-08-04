using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Musics.Commands.Create
{
    public record CreateMusicCommandRequest(int ProviderId, int MusicTypeId, int ArtistId, string Title, int Duration, DateTime PublicationDate ) : IRequest<MusicDTO>;
    public class CreateMusicCommandHandler(IBaseRepository<Music> _musicRepository) : IRequestHandler<CreateMusicCommandRequest, MusicDTO>
    {
        public async ValueTask<MusicDTO> Handle(CreateMusicCommandRequest request, CancellationToken cancellationToken)
        {
            Music? music = await _musicRepository.AddAsync(request.Adapt<Music>());
            await _musicRepository.SaveAsync();
            return music.Adapt<MusicDTO>();
        }
    }

}
