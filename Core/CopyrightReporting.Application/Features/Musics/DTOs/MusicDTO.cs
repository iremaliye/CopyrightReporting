namespace CopyrightReporting.Application.Features.Musics.DTOs
{
    public record MusicDTO (
        int Id,
        string ProviderName, 
        string MusicTypeName,
        string ArtistName,
        string Title, 
        int Duration, 
        DateTime PublicationDate );

}
