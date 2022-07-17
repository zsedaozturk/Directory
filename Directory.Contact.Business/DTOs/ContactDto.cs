﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.Business.DTOs
{
    public class ContactDto
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid UserID { get; set; }
    }
}
