using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Abstract
{
    public interface IUserRepository
    {
        bool IsValid(string userName, string password);
        List<Entities.UserRole> UserRoles(string userName, string password);
    }
}
