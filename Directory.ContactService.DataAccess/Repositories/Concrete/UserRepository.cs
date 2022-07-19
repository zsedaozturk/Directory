using Directory.ContactService.DataAccess.CSContext;
using Directory.ContactService.DataAccess.Entities;
using Directory.ContactService.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Directory.ContactService.DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ContactServiceContext _ucontext;
        public UserRepository(ContactServiceContext context) : base(context)
        {
            _ucontext = context;
        }


        public void AddUser(User user)
        {
            _ucontext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _ucontext.Users.Remove(user);
        }

        public User getUserByUserId(Guid userId)
        {
            return _ucontext.Users.Where(x => x.ID == userId).FirstOrDefault();
        }

        public List<User> getAllUsers()
        {
            return _ucontext.Users.ToList();
        }


    }
}
