using OnlineShoppingService.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShoppingService.Domain.Entities;

namespace OnlineShoppingService.Domain.Concrete
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private Abstract.IEFDbContext _efDatabaseContext;

        public UserRepository(Abstract.IEFDbContext context)
        {
            _efDatabaseContext = context;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return _efDatabaseContext.GetUsers;
            }
        }

        public bool ClientKeyIsValid(string userName, string password)
        {
            return _efDatabaseContext.GetUsers.Any(u => u.Email.Equals(userName, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }

        public IEnumerable<UserRole> GetUserRoles(string userId)
        {
            return _efDatabaseContext.UserRoles().Where(ur => ur.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_efDatabaseContext != null)
                {
                    _efDatabaseContext.Dispose();
                    _efDatabaseContext = null;
                }
            }
        }
    }
}
