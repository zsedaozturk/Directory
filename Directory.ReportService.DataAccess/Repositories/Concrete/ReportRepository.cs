﻿using Directory.ReportService.DataAccess.Entities;
using Directory.ReportService.DataAccess.Repositories.Abstract;
using Directory.ReportService.DataAccess.RSContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directory.ReportService.DataAccess.Repositories.Concrete
{
    public class ReportRepository : IReportRepository
    {

        protected ReportServiceContext _rcontext;
        public ReportRepository(ReportServiceContext context)
        {
            _rcontext = context;
        }


        public void AddReport(Report report)
        {
            _rcontext.Reports.Add(report);
            _rcontext.SaveChanges();
        }


        public List<Report> GetReports()
        {
            return _rcontext.Reports.ToList();
        }

        public Report GetReportById(Guid id)
        {
            return _rcontext.Reports.FirstOrDefault(x => x.ID == id);
        }
        public void DeleteReport(Report report)
        {
            _rcontext.Reports.Remove(report);
            _rcontext.SaveChanges();
        }


    }
}
