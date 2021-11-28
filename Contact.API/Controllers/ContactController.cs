using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        ///     Rehberlerin listesini döner.
        /// </summary>
        ///

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<ContactDto>>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _contactService.GetAllAsync();

            return result.Error ? BadRequest(result) : Ok(result);
        }

        /// <summary>
        ///    Rehberleri iletişim bilgisi ile döner.
        /// </summary>
        [HttpGet("communication")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<ContactDetailDto>>))]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await _contactService.GetAllWithDetailAsync();

            return result.Error ? BadRequest(result) : Ok(result);

        }

        /// <summary>
        ///    Id'si girilen Rehberi döner.
        /// </summary>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ContactDto>))]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _contactService.GetAsync(id);

            return result.Error ? BadRequest(result) : Ok(result);

        }

        /// <summary>
        ///    Id'si girilen Rehberi iletişim bilgisi ile birlikte döner.
        /// </summary>

        [HttpGet("{id}/communication")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ContactDetailDto>))]
        public async Task<IActionResult> GetWithDetailAsync(Guid id)
        {
            var result = await _contactService.GetDetailAsync(id);

            return result.Error ? BadRequest(result) : Ok(result);

        }
        /// <summary>
        ///   Rehber ekler.
        /// </summary>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> PostAsync(ContactCreateDto contactCreateDto)
        {
            var result = await _contactService.CreateAsync(contactCreateDto);

            return result.Error ? BadRequest(result) : Ok(result);

        }

        /// <summary>
        ///   Rehber günceller.
        /// </summary>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> PutAsync(ContactUpdateDto contactUpdateDto)
        {
            var result = await _contactService.UpdateAsync(contactUpdateDto);

            return result.Error ? BadRequest(result) : Ok(result);
        }

        /// <summary>
        ///   Rehber siler.
        /// </summary>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _contactService.DeleteAsync(id);

            return result.Error ? BadRequest(result) : Ok(result);
        }
    }
}
