using CopyrightReporting.Application;
using Microsoft.AspNetCore.Mvc;

namespace CopyrightReporting.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ServiceReportGenerator _reportGenerator;

        public ReportController(ServiceReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport([FromQuery] string sqlQuery)
        {
            try
            {
                await _reportGenerator.GenerateReport(sqlQuery);
                return Ok("Rapor başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Rapor oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
