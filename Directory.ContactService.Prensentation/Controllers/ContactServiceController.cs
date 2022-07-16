﻿using Directory.ContactService.Business.DTOs;
using Directory.ContactService.Business.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.ContactService.Prensentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactServiceController : Controller
    {

        IUserManager userManager;
        IContactManager contactManager;
        public ContactServiceController(IUserManager _userManager, IContactManager _contactManager)
        {
            userManager = _userManager;
            contactManager = _contactManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddUser(UserDto userDto)
        {
            Guid guid = Guid.NewGuid();
            userDto.UserID = guid;
            userManager.AddUser(userDto);
        }
        [HttpDelete]
        public void DeleteUser(UserDto userDto)
        {
            contactManager.DeleteContactByUserId(userDto.UserID);
            userManager.DeleteUser(userDto.UserID);

        }

        public void DeleteContact(ContactDto contactDto)
        {
            contactManager.DeleteContact(contactDto.ID);
        }

        [HttpPost]
        public void AddContact(ContactDto contactDto)
        {
            contactManager.AddContact(contactDto);
        }

        [HttpGet]
        public List<UserDto> getAllUsersContacts()
        {
            List<UserDto> listusers = userManager.getAllUsersContacts();
            return listusers;
        }
        [HttpPost]
        public List<ContactDto> GetContact(ContactDto contactDto)
        {
            return contactManager.getAllContactsById(contactDto.UserID);
        }

        [HttpPost]
        public ReportDto CreateReport(ContactDto contactDto)
        {
            List<int> counts = contactManager.PersonPhoneCount(contactDto.Address);
            ReportDto reportDto = new ReportDto();
            reportDto.Location = contactDto.Address;
            reportDto.UserCount = counts[0];
            reportDto.PhoneCount = counts[1];

            return reportDto;
        }


    }
}