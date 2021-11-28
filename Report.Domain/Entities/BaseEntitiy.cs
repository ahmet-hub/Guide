using System;

namespace Report.Domain.Entities
{
    public class BaseEntitiy
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
