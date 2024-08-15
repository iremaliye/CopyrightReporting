using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Musics.Commands.Create
{
    public record CreateMusicCommandRequest(int ProviderId, int MusicTypeId, List<int> ArtistIds, string Title, int Duration, DateTime PublicationDate) : IRequest<MusicDTO>;
    public class CreateMusicCommandHandler(IBaseRepository<Music> _musicRepository, IBaseRepository<Artist> _artistRepository) : IRequestHandler<CreateMusicCommandRequest, MusicDTO>
    {
        public async ValueTask<MusicDTO> Handle(CreateMusicCommandRequest request, CancellationToken cancellationToken)
        {
            Music? music = await _musicRepository.AddAsync(request.Adapt<Music>());
            List<Artist>? data= await(await _artistRepository.GetAllAsync()).Where(a=>request.ArtistIds.Contains(a.Id)).ToListAsync();
            music.Artists = data;
            await _musicRepository.SaveAsync();
            return music.Adapt<MusicDTO>();
        }
    }

}
