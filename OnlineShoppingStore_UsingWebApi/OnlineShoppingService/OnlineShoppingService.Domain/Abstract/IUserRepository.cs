using OnlineShoppingService.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShoppingService.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        //IEnumerable<UserRole> UserRoles { get; }
        bool ClientKeyIsValid(string userName,string password);
        IEnumerable<UserRole> GetUserRoles(string UserId);
    }
}
