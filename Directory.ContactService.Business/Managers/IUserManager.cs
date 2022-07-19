using Directory.ContactService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.Business.Managers
{
    public interface IUserManager
    {
        void AddUser(UserDto userDto);

        void DeleteUser(Guid userId);
        List<UserDto> getAllUsersContacts();

    }
}
