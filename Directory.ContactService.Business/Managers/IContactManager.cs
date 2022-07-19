using Directory.ContactService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.Business.Managers
{
    public interface IContactManager
    {
        void AddContact(ContactDto contactDto);
        void DeleteContact(int contactId);
        void DeleteContactByUserId(Guid userId);
        ContactDto getContactByUserId(Guid userId);
        List<ContactDto> getAllContactsById(Guid userId);
        List<int> PersonPhoneCount(string address);
    }
}
