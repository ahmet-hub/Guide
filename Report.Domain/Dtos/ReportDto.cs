using System;

namespace Report.Domain.Dtos
{
    public class ReportDto
    {
        public Guid Id{ get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public string Statu { get; set; }
        public string Path { get; set; }
    }
}
