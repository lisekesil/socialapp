using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Repositories
{
    public interface IUserRepository
    {
        UserModel AddUser(UserModel user);

        UserModel Find(string userName);
        void Delete(string userName);
        IList<UserModel> FindAll();
        List<UserModel> FindUsersBySearch(string searching);
        UserModel FindById(string id);
    }
}
