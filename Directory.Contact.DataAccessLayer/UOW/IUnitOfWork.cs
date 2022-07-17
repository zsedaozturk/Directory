using Directory.ContactService.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IContactRepository ContactRepository { get; }
        void Save();
    }
}
