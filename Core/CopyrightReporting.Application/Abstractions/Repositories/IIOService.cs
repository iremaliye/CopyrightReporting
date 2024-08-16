namespace CopyrightReporting.Application.Abstractions.Repositories
{
    public interface IIOService
    {
        Task WriteToText(IEnumerable<string> data, string filePath, string delimiter = "    ");
       
    }
}
