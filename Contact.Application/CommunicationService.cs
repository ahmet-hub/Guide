using AutoMapper;
using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Communication;
using Contact.Domain.Entities;
using Contact.Domain.Models;
using Contact.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Contact.Application
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IRepository<Communication> _repository;
        private readonly IMapper _mapper;
        public CommunicationService(IRepository<Communication> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CommunicationDto>> CreateAsync(CommunicationCreateDto communicationCreateDto)
        {
            var result = await _repository.AddAsync(_mapper.Map<Communication>(communicationCreateDto));

            if (result == null)
                return Response.Fail<CommunicationDto>("");

            return Response.Ok(_mapper.Map<CommunicationDto>(result), "");
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
    }
}
