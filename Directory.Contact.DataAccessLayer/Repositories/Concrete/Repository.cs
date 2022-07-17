using Directory.ContactService.DataAccess.CSContext;
using Directory.ContactService.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.DataAccess.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected ContactServiceContext _context;
        private DbSet<T> _dbSet;
        public Repository(ContactServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


    }
}
