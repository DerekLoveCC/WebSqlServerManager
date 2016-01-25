using SqlServer.Entity.Entities;
using SqlServer.Entity.Repositories.Interface;
using System;
using System.Data.Entity;

namespace SqlServer.Entity.Repositories.Impl
{
    public class SsmUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext = new SsmDbContext();

        private IGenericRepository<User> _userRepository;

        public IGenericRepository<User> UserRepository => _userRepository ?? (_userRepository = new SsmDbRepository<User>(_dbContext));

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