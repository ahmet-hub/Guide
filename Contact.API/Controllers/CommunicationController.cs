using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Communication;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;
        public CommunicationController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;

        }

        /// <summary>
        ///   Rehbere iletişim bilgisi ekler.
        /// </summary>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> PostAsync(CommunicationCreateDto communicationCreateDto)
        {
            var result = await _communicationService.CreateAsync(communicationCreateDto);

            return result.Error ? BadRequest(result) : Ok(result);

        }

        /// <summary>
        ///    Rehberden iletişim bilgisi siler.
        /// </summary>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _communicationService.DeleteAsync(id);

            return result.Error ? BadRequest(result) : Ok(result);
        }

    }
}

