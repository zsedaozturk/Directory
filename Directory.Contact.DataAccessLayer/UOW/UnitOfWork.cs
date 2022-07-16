using Directory.ContactService.DataAccess.CSContext;
using Directory.ContactService.DataAccess.Repositories.Abstract;
using Directory.ContactService.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.DataAccess.UOW
{
       public class UnitOfWork : IUnitOfWork
    {
        
        private ContactServiceContext usContext;
        public UnitOfWork(ContactServiceContext context)
        {
            usContext = context;
            UserRepository = new UserRepository(usContext);
            ContactRepository = new ContactRepository(usContext);
        }
        
        public IUserRepository UserRepository { get; private set; }

        public IContactRepository ContactRepository { get; private set; }
        
        public void Save()
        {
            usContext.SaveChanges();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
