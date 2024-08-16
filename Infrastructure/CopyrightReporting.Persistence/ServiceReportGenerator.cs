using CopyrightReporting.Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using CopyrightReporting.Persistence.Contexts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace CopyrightReporting.Application
{
    public class ServiceReportGenerator
    {
        private readonly IIOService _ioService;
        private readonly CopyrightReportingDbContext _context;

        public ServiceReportGenerator(IIOService ioService, CopyrightReportingDbContext context)
        {
            _ioService = ioService;
            _context = context;
        }

        public async Task GenerateReport(string sqlQuery,string delimiter)
        {
            try
            {
                var (columnNames, data) = await FetchDataFromDatabase(sqlQuery,delimiter);
                var reportData = FormatReportData(columnNames, data, delimiter);
                await _ioService.WriteToText(reportData, @"C:\Users\MONSTER\Desktop\Raporlar\rapor.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rapor oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        private async Task<(string columnNames, IEnumerable<string> data)> FetchDataFromDatabase(string sqlQuery,string delimiter)
        {
            try
            {
                var data = new List<string>();
                var columnNames = string.Empty;

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sqlQuery;
                        command.CommandType = CommandType.Text;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            columnNames = PutColumnNames(reader, delimiter);
                            data = PutDataRows(reader, delimiter).ToList();  
                        }
                    }
                }

                return (columnNames, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veri çekme hatası: {ex.Message}");
                return (string.Empty, Enumerable.Empty<string>());
            }
        }

        private string PutColumnNames(IDataReader reader, string delimiter)
        {
            var columnCount = reader.FieldCount;
            var columnNamesList = new List<string>();
            for (int i = 0; i < columnCount; i++)
            {
                columnNamesList.Add(reader.GetName(i));
            }
            return string.Join(delimiter, columnNamesList);
        }

        private IEnumerable<string> PutDataRows(IDataReader reader, string delimiter)
        {
            var data = new List<string>();
            var columnCount = reader.FieldCount;

            while (reader.Read())
            {
                var rowValues = new List<string>();
                for (int i = 0; i < columnCount; i++)
                {
                    rowValues.Add(reader.GetValue(i).ToString());
                }
                data.Add(string.Join(delimiter, rowValues));
            }

            return data;
        }

        private IEnumerable<string> FormatReportData(string columnNames, IEnumerable<string> data,string delimiter)
        {
            var reportData = new List<string> { columnNames };
            reportData.AddRange(data); // Veriyi ekle
            return reportData;
        }
    }
}
