using Skaitykla._Domain;
using Skaitykla.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Skaitykla.MVC.Services
{
    public class InMemoryUserData
    {

        List<User> users;

        public InMemoryUserData()
        {
            if (users == null)
            {
                users = new List<User>()
            {
                new User   { ID = 1, Name = "Mike", Email = "sancho.panso@gmail.com", Password = "sancho", IsAdmin = false },
                new User   { ID = 2, Name = "Lukas",Email = "slaptas2draugas@gmail.com", Password = "slaptas", IsAdmin = false},
                new User   { ID = 3, Name = "Gytis", Email = "dragelys@gmail.com", Password = "dragelys", IsAdmin = false},
                new User   { ID = 4, Name = "Admin", Email = "admin@gmail.com", Password = "admin" ,IsAdmin = true},
            };
            }
        }

        public User GetByEmail(LoginViewModel model)
        {
            return users.Find(user=>user.Email == model.Email);
        }

        public void AddUser(User user)
        {
            users.Add(user);
            user.ID = users.Max(r => r.ID) + 1;
        }

    }
}
