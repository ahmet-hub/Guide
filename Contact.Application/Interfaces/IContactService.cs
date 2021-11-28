using Contact.Domain.Dtos.Contact;
using Contact.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces
{
    public interface IContactService
    {
        Task<Response<List<ContactDto>>> GetAllAsync();
        Task<Response<List<ContactDetailDto>>> GetAllWithDetailAsync();
        Task<Response<ContactDto>> GetAsync(Guid id);
        Task<Response<ContactDetailDto>> GetDetailAsync(Guid id);
        Task<Response<ContactDto>> CreateAsync(ContactCreateDto contactCreateDto);
        Task<Response<bool>> UpdateAsync(ContactUpdateDto contactUpdateDto);
        Task<Response<bool>> DeleteAsync(Guid id);
        Task<Response<Report>> GetLocationReportAsync(string location);
    }
}
