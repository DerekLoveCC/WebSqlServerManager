using SqlServer.Entity.Entities;
using SqlServer.Entity.Repositories.Interface;
using System;
using System.Data.Entity;

namespace SqlServer.Entity.Repositories.Impl
{
    public class SsmUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _dbContext = new SsmDbContext();

        private IGenericRepository<User> _userRepository;

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new SsmDbRepository<User>(_dbContext);
                }
                return _userRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}