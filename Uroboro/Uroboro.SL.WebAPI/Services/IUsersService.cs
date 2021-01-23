using System.Collections.Generic;
using Uroboro.Common.Models;

namespace Uroboro.SL.WebAPI.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers();
    }
}
