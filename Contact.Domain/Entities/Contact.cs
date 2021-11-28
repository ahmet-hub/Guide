using System.Collections.Generic;

namespace Contact.Domain.Entities
{
    public class Contact : BaseEntitiy
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<Communication> Communications { get; set; }
    }
}
