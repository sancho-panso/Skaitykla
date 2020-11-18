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
    
    public class LendingServices : ILendingService
    {
        private readonly BookContext _db;
        private readonly IBookService _bookService;

        public LendingServices(BookContext db, IBookService bookService)
        {
            _db = db;
            _bookService = bookService;
        }

        public LendingBook BorrowBook(int bookID, User user)
        {
            LendingBook lending = new LendingBook()
            {
                LendedBook = _bookService.GetBookById(bookID),
                User = user,
                TimeFrom = DateTime.Now
            };
            _db.Add(lending);
            _db.SaveChanges();

            return lending;
        }

        public List<Book> GetLendedBooks()
        {
            var books = _db.Books.Include(b => b.Author).ToList();
            var lendings = _db.Lendings.ToList();
            List<Book> lendedBooks = new List<Book>();
            foreach (var book in books)
            {
                foreach (var item in lendings)
                {
                    if (book.ID==item.LendedBook.ID)
                    {
                        lendedBooks.Add(book);
                    }
                }
            };

            return lendedBooks;
         }

        public List<Book> GetAvailableBooks()
        {
            List<Book> allBooks = _bookService.GetBooks();
            List<Book> lendedBooks = GetLendedBooks();
            List<Book> availableBooks = allBooks.Where(b => !lendedBooks.Contains(b)).ToList();
            return availableBooks;
        }

        public bool IsBookAvailable(int bookID)
        {
            Book book = _bookService.GetBookById(bookID);
            if (GetLendedBooks().Contains(book))
            {
                return false;
            }
            return true;
        }

        public List<Book> GetAvailableBooksByTime()
        {
            List<Book> availableBooks = _db.Books
                        .Include(b =>b.Author)
                        .Include(b => b.Lendings)
                        //.Where(b => !b.Lendings.Where(l => l.TimeTo < DateTime.Now).Any()).ToList();
                        .Where(b => !b.Lendings.Where(l => l.isAvailable).Any()).ToList();
            return availableBooks;
        }
    }
}
