using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Application.Features.MusicTypes.DTOs;
using CopyrightReporting.Domain.Entities;
using Mapster;
using Mediator;

namespace CopyrightReporting.Application.Features.MusicTypes.Commands.Delete
{
    public record DeleteMusicTypeCommandRequest (int Id) : IRequest<MusicTypeDTO>;
    public class DeleteMusicTypeCommandHandler(IBaseRepository<MusicType> _musicRepository) : IRequestHandler<DeleteMusicTypeCommandRequest, MusicTypeDTO>
    {
        public async ValueTask<MusicTypeDTO> Handle(DeleteMusicTypeCommandRequest request, CancellationToken cancellationToken)
        {
            MusicType? deletedMusicType = await _musicRepository.DeleteAsync(request.Id);
            await _musicRepository.SaveAsync();
            return deletedMusicType.Adapt<MusicTypeDTO>();

        }
    }
}
