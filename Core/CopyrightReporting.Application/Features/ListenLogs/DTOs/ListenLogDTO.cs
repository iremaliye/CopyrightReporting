using CopyrightReporting.Application.Features.Packages.DTOs;
using CopyrightReporting.Application.Features.Providers.DTOs;

namespace CopyrightReporting.Application.Features.ListenLogs.DTOs
{
    public record class ListenLogDTO(
        
        int Id,
        string MusicTitle, 
        string PackageName, 
        int Duration);
   
}
