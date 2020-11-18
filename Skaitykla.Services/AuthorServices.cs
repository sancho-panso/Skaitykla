using Microsoft.EntityFrameworkCore;
using Skaitykla._Domain;
using Skaitykla._EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skaitykla.MVC.Models;
using System.Web.Mvc;
using Skaitykla.Services.Interfaces;

namespace Skaitykla.Services
{
    public class AuthorServices: IAuthorService
    {
        private readonly BookContext _db;
        private readonly IBookService bookServices;

        public AuthorServices(BookContext db, IBookService bookServices)
        {
            _db = db;
            this.bookServices = bookServices;
        }

        public  IEnumerable<Author> GetAuthors()
        {
            return _db.Authors.Include(x => x.AuthorBooks).ToList();
        }

        public Author CreateAuthor(AuthorViewModel model)
        {
           
                    Author newAuthor = new Author(model.Name, model.Surname);
                    _db.Authors.Add(newAuthor);
                    _db.SaveChanges();

                     return newAuthor;
           
            
        }

        public Author GetAuthorById(Guid id)
        {
            Author author = _db.Authors.Where(a => a.ID == id).Include(b => b.AuthorBooks).FirstOrDefault();
            return author;
        }

        public void AddAuthorBook(NewBookViewModel model)
        {
            var author = GetAuthorById(model.AuthorId);
            author.AuthorBooks.Add(
                new Book { Title = model.Title }
                );
            _db.Authors.Update(author);
            _db.SaveChanges();

        }

        public void Remove(Guid id)
        {
            _db.Authors.Remove(GetAuthorById(id));
            _db.SaveChanges();
        }

        public void Edit(Guid id, AuthorViewModel model)
        {
            Author author = GetAuthorById(id);
            author.Name = model.Name;
            author.Surname = model.Surname;
            _db.SaveChanges();

        }
    }
}
