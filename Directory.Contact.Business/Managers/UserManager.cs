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
    public class UserManager : IUserManager
    {
        UnitOfWork uow = new UnitOfWork(new ContactServiceContext());



        public User ConvertToUser(UserDto userDto)
        {
            User user = new User();
            user.ID = userDto.UserID;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.CompanyName = userDto.CompanyName;
            return user;
        }
        public void AddUser(UserDto userDto)
        {
            User user = ConvertToUser(userDto);
            uow.UserRepository.AddUser(user);
            uow.Save();
        }
        public void DeleteUser(Guid userId)
        {
            User user = uow.UserRepository.getUserByUserId(userId);
            uow.UserRepository.DeleteUser(user);
            uow.Save();
        }

        public List<UserDto> getAllUsersContacts()
        {
            List<UserDto> userDtos = uow.UserRepository.getAllUsers().Select(x => new UserDto
            {
                UserID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CompanyName = x.CompanyName

            }).ToList();

            var usersIDs = userDtos.Select(x => x.UserID).ToList();

            var contactsDtos = uow.ContactRepository.getAllContacts().Where(x => usersIDs.Contains(x.UserID)).Select(y => new ContactDto
            {
                ID = y.ID,
                Email = y.Email,
                PhoneNumber = y.PhoneNumber,
                Address = y.Address,
                UserID = y.UserID

            }).ToList();


            foreach (var item in userDtos)
            {
                item.contactDtos = contactsDtos.Where(x => x.UserID == item.UserID).ToList();

            }

            return userDtos;
        }

    }
}
