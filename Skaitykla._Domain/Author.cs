using System;
using System.Collections.Generic;

namespace Skaitykla._Domain
{
    public class Author
    {
        public Author(string name, string surname)
        {
            Guid ID = Guid.NewGuid();
            Name = name;
            Surname = surname;
            AuthorBooks = new List<Book>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid ID { get; set; }
        public List<Book> AuthorBooks { get; set; }
    }
}