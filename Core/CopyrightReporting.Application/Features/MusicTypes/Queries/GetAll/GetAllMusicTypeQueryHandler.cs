using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Features.MusicTypes.Queries.GetAll
{
    public record GetAllMusicTypesQueryRequest() : IRequest<List<MusicTypeDTO>>;
    public class GetAllMusicTypesQueryHandler(IBaseRepository<MusicType> _musicTypeRepository) : IRequestHandler<GetAllMusicTypesQueryRequest, List<MusicTypeDTO>>
    {
        public async ValueTask<List<MusicTypeDTO>> Handle(GetAllMusicTypesQueryRequest request, CancellationToken cancellationToken)
        {
           return await _musicTypeRepository.GetAllAsync().Result.Where(mt => mt.IsActive).ProjectToType<MusicTypeDTO>().ToListAsync();
        }
    }
}
