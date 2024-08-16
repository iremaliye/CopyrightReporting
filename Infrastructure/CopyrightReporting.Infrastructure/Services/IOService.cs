using CopyrightReporting.Application.Abstractions.Repositories;

namespace CopyrightReporting.Infrastructure.Services
{
    public class IOService :IIOService
    {
      

        public async Task WriteToText(IEnumerable<string> data, string filePath, string delimiter = "    ")
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var line in data)
                    {
                        var formattedLine = string.Join(delimiter, line.Split('\t'));
                        await writer.WriteLineAsync(formattedLine);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine($"Dosya yazma hatası: {ex.Message}");
            }
        }

    }

}


