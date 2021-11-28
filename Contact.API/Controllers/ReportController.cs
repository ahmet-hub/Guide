using Contact.Application.Interfaces;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ReportController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("location")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<Report>>))]
        public async Task<IActionResult> GetReportAsync(string location)
        {
            var result = await _contactService.GetLocationReportAsync(location);

            return result.Error ? BadRequest(result) : Ok(result);
        }
    }
}
