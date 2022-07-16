using System;
using System.Collections.Generic;
using System.Text;
using Directory.ContactService.DataAccess.Entities;


namespace Directory.ContactService.DataAccess.Repositories.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
        void AddContact(Contact contact);
        Contact getContactByUserId(Guid userId);
        Contact getContactById(int contactId);
        void DeleteContact(Contact contact);
        List<Contact> getAllContacts();
        List<Contact> GetAllContactsById(Guid userId);

        List<int> PersonPhoneCount(string address);
    }
}
