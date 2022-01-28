using Microsoft.EntityFrameworkCore.ChangeTracking;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private AppDbContext context;
        public EFUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public UserModel AddUser(UserModel user)
        {
            EntityEntry<UserModel> entityEntry = context.Users.Add(user);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public UserModel Find(string userName)
        {
            return context.Users.SingleOrDefault(el => el.UserName == userName);
        }

        public void Delete(string userName)
        {
            var user = context.Users.SingleOrDefault(el => el.UserName == userName);
            if(user != null)
            { 
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
        public IList<UserModel> FindAll()
        {
            return context.Users.ToList();
        }
        public List<UserModel> FindUsersBySearch(string searching)
        {
            return context.Users.Where(u => u.FirstName.Contains(searching) || u.LastName.Contains(searching)).ToList();
        }

        public UserModel FindById(string id)
        {
            return context.Users.SingleOrDefault(el => el.Id == id);
        }
    }
}
