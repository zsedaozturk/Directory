using Directory.ReportService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ReportService.DataAccess.Repositories.Abstract
{
    public interface IReportRepository
    {
        void AddReport(Report report);
        List<Report> GetReports();
        Report GetReportById(Guid id);
        void DeleteReport(Report report);
    }
}
