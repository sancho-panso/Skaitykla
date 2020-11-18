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
    public class BookServices : IBookService
    {
        private readonly BookContext _db;

        public BookServices(BookContext db)
        {
            _db = db;

        }

        public int CreateBook(Book book)
        {
            _db.Books.Add(book);
            return _db.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return _db.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            return _db.Books.Include(b=>b.Author).ToList();
        }

    }
}
