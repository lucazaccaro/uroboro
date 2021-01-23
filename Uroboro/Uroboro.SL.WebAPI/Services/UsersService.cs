using System.Collections.Generic;
using Uroboro.Common.Models;

namespace Uroboro.SL.WebAPI.Services
{
    public class UsersService : IUsersService
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User() { Username = "admin", Password = "password", Name = "Administrator", Email = "admin@domain.com" }
            };
        }
    }
}
