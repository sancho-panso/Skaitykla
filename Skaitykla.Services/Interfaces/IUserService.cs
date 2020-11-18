using Skaitykla._Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skaitykla.Services.Interfaces
{
    public interface IUserService
    {
       User GetUserById(int id);

        List<Book> GetUserBooks(int id);
    }
}
