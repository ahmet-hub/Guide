using System;

namespace Contact.Domain.Entities
{
    public class Communication : BaseEntitiy
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public Guid ContactId { get; set; }
    }
}
