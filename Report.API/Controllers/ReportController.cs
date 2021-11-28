using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Interfaces;
using Report.Domain.Dtos;
using Report.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Guid>))]
        public async Task<IActionResult> GenerateReportAsync(string location)
        {
            var result = await _reportService.GenerateReportAsync(location);

            return result.Error ? BadRequest(result) : Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ReportDto>))]
        public async Task<IActionResult> GetReportAsync(Guid reportId)
        {
            var result = await _reportService.GetAsync(reportId);

            return result.Error ? BadRequest(result) : Ok(result);
        }
    }
}
