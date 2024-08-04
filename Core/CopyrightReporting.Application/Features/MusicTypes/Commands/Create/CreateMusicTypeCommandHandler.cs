using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.MusicTypes.Commands.Create
{
    public record CreateMusicTypeCommandRequest(string Name) : IRequest<MusicTypeDTO>;
    public class CreateMusicTypeCommandHandler(IBaseRepository<MusicType> _musicTypeRepository) : IRequestHandler<CreateMusicTypeCommandRequest, MusicTypeDTO>
    {
        public async ValueTask<MusicTypeDTO> Handle(CreateMusicTypeCommandRequest request, CancellationToken cancellationToken)
        {
            MusicType? musicType = await _musicTypeRepository.AddAsync(request.Adapt<MusicType>());
            await _musicTypeRepository.SaveAsync();
            return musicType.Adapt<MusicTypeDTO>();

        }
    }
}
