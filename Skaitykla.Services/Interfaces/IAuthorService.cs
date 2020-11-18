using Skaitykla._Domain;
using Skaitykla.MVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skaitykla.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();
        Author CreateAuthor(AuthorViewModel model);
        Author GetAuthorById(Guid id);
        void AddAuthorBook(NewBookViewModel model);
        void Remove(Guid id);
        void Edit(Guid id, AuthorViewModel model);
    }
}
