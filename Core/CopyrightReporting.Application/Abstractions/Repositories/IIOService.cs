namespace CopyrightReporting.Application.Abstractions.Repositories
{
    public interface IIOService
    {
        Task CreateReport(string sqlQuery, string filePath, string delimiter = "    ");
    }
}
