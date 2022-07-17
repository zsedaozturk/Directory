using Directory.ReportService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ReportService.Business.Managers
{
    public interface IReportManager
    {
        void AddReport(ReportDto reportDto);
        List<ReportDto> GetReports();
        void DeleteReport(Guid id);
    }
}
