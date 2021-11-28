using Contact.Domain.Dtos.Communication;
using Contact.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Contact.Application.Interfaces
{
    public interface ICommunicationService
    {
        Task<Response<CommunicationDto>> CreateAsync(CommunicationCreateDto communicationCreateDto);
        Task<Response<bool>> DeleteAsync(Guid id);
    }
}
