using Report.Domain.Dtos;
using Report.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Report.Application.Interfaces
{
    public interface IReportService
    {
        Task<Response<ReportDto>> GetAsync(Guid reprotId);
        Task<Response<Guid>> GenerateReportAsync(string location);
    }
}
