using Directory.ContactService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.DataAccess.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        void AddUser(User user);
        User getUserByUserId(Guid userId);
        void DeleteUser(User user);
        List<User> getAllUsers();

    }
}
