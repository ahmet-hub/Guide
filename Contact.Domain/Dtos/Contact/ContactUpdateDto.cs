using System;

namespace Contact.Domain.Dtos.Contact
{
    public class ContactUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
