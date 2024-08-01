using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Musics.Commands.Delete
{
    public record DeleteMusicCommandRequest(int Id) : IRequest<MusicDTO>;
    public class DeleteMusicCommandHandler(IBaseRepository<Music> _musicRepository) : IRequestHandler<DeleteMusicCommandRequest, MusicDTO>
    {
        public async ValueTask<MusicDTO> Handle(DeleteMusicCommandRequest request, CancellationToken cancellationToken)
        {
            Music? deletedmusic = await _musicRepository.DeleteAsync(request.Id);
            await _musicRepository.SaveAsync();
            return deletedmusic.Adapt<MusicDTO>();
        }
    }
}
