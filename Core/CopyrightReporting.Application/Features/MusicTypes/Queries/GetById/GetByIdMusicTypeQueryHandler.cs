using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.MusicTypes.Queries.GetById
{
    public record GetByIdMusicTypeQueryRequest(int Id) : IRequest<MusicTypeDTO>;
    public class GetByIdMusicTypeQueryHandler(IBaseRepository<MusicType> _musicTypeRepository) : IRequestHandler<GetByIdMusicTypeQueryRequest, MusicTypeDTO>
    {
        public async ValueTask<MusicTypeDTO> Handle(GetByIdMusicTypeQueryRequest request, CancellationToken cancellationToken)
        {
            MusicType? musicType = await _musicTypeRepository.GetAsync(request.Id);
            return musicType.Adapt<MusicTypeDTO>();
        }
    }
}
