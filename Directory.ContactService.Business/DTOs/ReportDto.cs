using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.Business.DTOs
{
    public class ReportDto
    {

        public string Location { get; set; }
        public int UserCount { get; set; }
        public int PhoneCount { get; set; }

    }
}
