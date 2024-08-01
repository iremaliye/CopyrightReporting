using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.MusicTypes.Commands.Update
{
    public record UpdateMusicTypeCommandRequest (int Id, string Name, bool IsActive) : IRequest<MusicTypeDTO>;
    public class UpdateMusicTypeCommandHandler(IBaseRepository<MusicType> _musicTypeRepository) : IRequestHandler<UpdateMusicTypeCommandRequest, MusicTypeDTO>
    {
        public async ValueTask<MusicTypeDTO> Handle(UpdateMusicTypeCommandRequest request, CancellationToken cancellationToken)
        {
            MusicType? updatedEntity = await _musicTypeRepository.UpdateAsync(request.Adapt<MusicType>());
            await _musicTypeRepository.SaveAsync();
            return updatedEntity.Adapt<MusicTypeDTO>();
        }
    }
}
