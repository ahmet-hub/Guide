using AutoMapper;
using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.Models;
using Contact.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Application
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;

        private readonly IMapper _mapper;

        public ContactService(IRepository<Domain.Entities.Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<ContactDto>>> GetAllAsync()
        {
            return Response.Ok(_mapper.Map<List<ContactDto>>(await _repository.GetAllAsync()), "");
        }

        public async Task<Response<List<ContactDetailDto>>> GetAllWithDetailAsync()
        {
            return Response.Ok(_mapper.Map<List<ContactDetailDto>>(await _repository.GetAllAsync("Communications")), "");
        }

        public async Task<Response<ContactDto>> GetAsync(Guid id)
        {
            var result = await _repository.GetFilterAsync(x => x.Id == id);

            if (result == null)
                return Response.Fail<ContactDto>("Contact Not Found");

            return Response.Ok(_mapper.Map<ContactDto>(result), "");

        }

        public async Task<Response<ContactDetailDto>> GetDetailAsync(Guid id)
        {
            var result = await _repository.GetFilterAsync(x => x.Id == id);

            if (result == null)
                return Response.Fail<ContactDetailDto>("Contact Not Found");

            return Response.Ok(_mapper.Map<ContactDetailDto>(result), "");

        }

        public async Task<Response<ContactDto>> CreateAsync(ContactCreateDto contactCreateDto)
        {
            var result = await _repository.AddAsync(_mapper.Map<Domain.Entities.Contact>(contactCreateDto));

            if (result == null)
                return Response.Fail<ContactDto>("");

            return Response.Ok(_mapper.Map<ContactDto>(result), "");

        }

        public async Task<Response<bool>> UpdateAsync(ContactUpdateDto contactUpdateDto)
        {
            try
            {
                await _repository.UpdateAsync(_mapper.Map<Domain.Entities.Contact>(contactUpdateDto));
                return Response.Ok(true, "");
            }

            catch (Exception ex)
            {

                return Response.Fail<bool>(ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Response.Ok(true, "");
            }

            catch (Exception ex)
            {
                return Response.Fail<bool>(ex.Message);
            }
        }

        public async Task<Response<Report>> GetLocationReportAsync(string location)
        {

            var contact = await _repository.GetWhereAsync(x => x.Communications.All(y => y.Location == location), includeProperties: "Communications");

            return Response.Ok(new Report
            {
                PersonCount = contact.Count(),
                PhoneCount = contact.Sum(x => x.Communications.Count)
            }, "");
        }
    }
    
}
