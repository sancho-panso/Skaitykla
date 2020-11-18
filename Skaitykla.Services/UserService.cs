using Microsoft.EntityFrameworkCore;
using Skaitykla._Domain;
using Skaitykla._EF;
using Skaitykla.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skaitykla.Services
{
    public class UserService: IUserService
    {
        private readonly BookContext _db;
        private readonly ILendingService _lendService;
        public UserService(BookContext db, ILendingService lendService)
        {
            _db = db;
            _lendService = lendService;
        }

        public List<Book> GetUserBooks(int id)
        {
           List<LendingBook> lendings = _db.Lendings.Where(l => l.User.ID == id).ToList();
           List<Book> books = new List<Book>();
            foreach (var item in lendings)
            {
                books.Add(item.LendedBook);
            }
            return books;
        }

        public User GetUserById(int id)
        {
            return _db.Users.Where(u=>u.ID == id).FirstOrDefault();
        }
    }
}
