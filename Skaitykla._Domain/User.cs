using System;
using System.Collections.Generic;
using System.Text;

namespace Skaitykla._Domain
{
    public class User
    {
        public User()
        {
             BorowwedBooks = new List<Book>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Book> BorowwedBooks { get; set; }
        public bool IsAdmin { get; set; }
    }
}
