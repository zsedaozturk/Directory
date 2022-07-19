using Directory.ContactService.Business.DTOs;
using Directory.ContactService.DataAccess.CSContext;
using Directory.ContactService.DataAccess.Entities;
using Directory.ContactService.DataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directory.ContactService.Business.Managers
{
    public class ContactManager : IContactManager
    {
        UnitOfWork uow = new UnitOfWork(new ContactServiceContext());
        public Contact ConvertToContact(ContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.UserID = contactDto.UserID;
            contact.PhoneNumber = contactDto.PhoneNumber;
            contact.Email = contactDto.Email;
            contact.Address = contactDto.Address.ToUpper();

            return contact;
        }
        public ContactDto ConvertToContactDto(Contact contact)
        {
            ContactDto contactDto = new ContactDto();
            try
            {

                contactDto.UserID = contact.UserID;
                contactDto.PhoneNumber = contact.PhoneNumber;
                contactDto.Email = contact.Email;
                contactDto.Address = contact.Address;
            }
            catch
            {
                contactDto = null;
            }


            return contactDto;
        }
        public void AddContact(ContactDto contactDto)
        {
            Contact contact = ConvertToContact(contactDto);
            uow.ContactRepository.AddContact(contact);
            uow.Save();
        }
        
        public ContactDto getContactByUserId(Guid userId)
        {
            ContactDto contactDto = ConvertToContactDto(uow.ContactRepository.getContactByUserId(userId));
            return contactDto;

        }
       
        public List<ContactDto> getAllContactsById(Guid userId)
        {
            List<ContactDto> contacts = uow.ContactRepository.GetAllContactsById(userId).Where(x => x.UserID == userId).Select(y => new ContactDto
            {

                ID = y.ID,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                Address = y.Address,
                UserID = y.UserID


            }).ToList();

            return contacts;


        }

        
        public void DeleteContact(int contactId)
        {
            Contact contact = uow.ContactRepository.getContactById(contactId);
            uow.ContactRepository.DeleteContact(contact);
            uow.Save();
        }
        public void DeleteContactByUserId(Guid userId)
        {
            Contact contact = uow.ContactRepository.getContactByUserId(userId);
            uow.ContactRepository.DeleteContact(contact);
            uow.Save();
        }



        public List<int> PersonPhoneCount(string address)
        {
            return uow.ContactRepository.PersonPhoneCount(address);
        }
         

    }
}
