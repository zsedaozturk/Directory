using Directory.ReportService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ReportBusConfigurator.Models
{
    public class Report : IReportConsumer
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; }
        public string CreatedDate { get; set; }
        public ReportEnum status { get; set; }
    }
}
