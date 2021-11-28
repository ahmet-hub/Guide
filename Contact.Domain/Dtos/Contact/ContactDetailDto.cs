using Contact.Domain.Dtos.Communication;
using System.Collections.Generic;

namespace Contact.Domain.Dtos.Contact
{
    public class ContactDetailDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CommunicationDto> CommunicationDtos{ get; set; }
    }
}
