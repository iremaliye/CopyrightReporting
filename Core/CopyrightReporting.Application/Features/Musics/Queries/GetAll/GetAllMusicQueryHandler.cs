using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.Musics.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.Musics.Queries.GetAll
{
    public record GetAllMusicsQueryRequest(): IRequest<List<MusicDTO>>;
    public class GetAllMusicQueryHandler(IBaseRepository<Music> _musicRepository) : IRequestHandler<GetAllMusicsQueryRequest, List<MusicDTO>>
    {
        public async ValueTask<List<MusicDTO>> Handle(GetAllMusicsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _musicRepository.GetAllAsync().Result.Where(m=>m.IsActive).ProjectToType<MusicDTO>().ToListAsync();        
        }
    }
}
