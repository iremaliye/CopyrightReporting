using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Musics.Commands.Update
{
    public record UpdateMusicCommandRequest (int Id, int ProviderId, int MusicTypeId, string Title, int Duration, DateTime PublicationDate) : IRequest<MusicDTO>;
    public class UpdateMusicCommandHandler(IBaseRepository<Music> _musicRepository) : IRequestHandler<UpdateMusicCommandRequest, MusicDTO>
    {
        public async ValueTask<MusicDTO> Handle(UpdateMusicCommandRequest request, CancellationToken cancellationToken)
        {
            Music? updateEntity = await _musicRepository.UpdateAsync(request.Adapt<Music>());
            await _musicRepository.SaveAsync();
            return updateEntity.Adapt<MusicDTO>();
        }
    }
}
