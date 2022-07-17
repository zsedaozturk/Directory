using Directory.ContactService.DataAccess.CSContext;
using Directory.ContactService.DataAccess.Entities;
using Directory.ContactService.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directory.ContactService.DataAccess.Repositories.Concrete
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private ContactServiceContext _ccontext;
        public ContactRepository(ContactServiceContext context) : base(context)
        {
            _ccontext = context;
        }

        public void AddContact(Contact contact)
        {
            _ccontext.Contacts.Add(contact);
        }
        public Contact getContactByUserId(Guid userId)
        {
            Contact contact = _ccontext.Contacts.FirstOrDefault(x => x.UserID == userId);
            return contact;
        }
        public Contact getContactById(int contactId)
        {
            Contact contact = _ccontext.Contacts.FirstOrDefault(x => x.ID == contactId);
            return contact;
        }
        public void DeleteContact(Contact contact)
        {
            try
            {
                _ccontext.Contacts.Remove(contact);
            }
            catch
            {

            }

        }
        public List<Contact> getAllContacts()
        {
            return _ccontext.Contacts.ToList();
        }


        public List<Contact> GetAllContactsById(Guid userId)
        {
            return _ccontext.Contacts.ToList();
        }


        public List<int> PersonPhoneCount(string address)
        {
            List<int> counts = new List<int>();

            int userCount = _context.Contacts.Where(x => x.Address == address).Select(x => x.UserID).ToList().Distinct().Count();
            counts.Add(userCount);

            int phoneCount = _context.Contacts.Where(x => x.Address == address).Select(x => x.PhoneNumber).ToList().Count();
            counts.Add(phoneCount);

            return counts;
        }

    }
}
