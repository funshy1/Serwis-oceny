using System.Collections.Generic;
using projekt.Controllers.Resources;
using projekt.Models;

namespace projekt.Persistence
{
    public interface IUserRepository
    {
        User GetUser(string id);
        QueryResult<User> GetUsers();
        User UpdateUser(SaveUserResource user, string id);
    }
}