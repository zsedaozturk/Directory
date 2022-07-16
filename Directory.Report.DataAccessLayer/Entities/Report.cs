using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.Report.DataAccess.Entities
{
    public class Report
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; }

        public ReportEnum status { get; set; }
    }
}
