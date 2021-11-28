using System;

namespace Contact.Domain.Dtos.Communication
{
    public class CommunicationCreateDto
    {
        public Guid ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}
