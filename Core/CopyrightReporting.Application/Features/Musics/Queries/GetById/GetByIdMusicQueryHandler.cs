using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.Musics.Queries.GetById
{
    public record GetByIdMusicQueryRequest(int Id) : IRequest<MusicDTO>;
    public class GetByIdMusicQueryHandler(IBaseRepository<Music> _musicRepository) : IRequestHandler<GetByIdMusicQueryRequest, MusicDTO>
    {
        public async ValueTask<MusicDTO> Handle(GetByIdMusicQueryRequest request, CancellationToken cancellationToken)
        {
            Music? music = await _musicRepository.GetAsync(request.Id);
            return music.Adapt<MusicDTO>();
        }
    }
}
