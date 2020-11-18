using Skaitykla._Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skaitykla.Services.Interfaces
{
    public interface ILendingService
    {
        LendingBook BorrowBook(int bookID, User user);

        List<Book> GetLendedBooks();

        bool IsBookAvailable(int bookID);

        List<Book> GetAvailableBooks();
        List<Book> GetAvailableBooksByTime();
    }
}
