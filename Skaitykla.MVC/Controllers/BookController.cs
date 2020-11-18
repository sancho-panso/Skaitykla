using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaitykla._Domain;
using Skaitykla._EF;
using Skaitykla.MVC.Models;
using Skaitykla.Services;
using Skaitykla.Services.Interfaces;

namespace Skaitykla.MVC.Controllers
{
    [Authorize]
    public class BookController :Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly ILendingService _lendService;



        public BookController(IAuthorService service,
                            IBookService bookService,
                            ILendingService lendingService)
        {
            _authorService = service;
            _bookService = bookService;
            _lendService = lendingService;
        }
   
        public  IActionResult Index ()
        {
            
            return View(_lendService.GetAvailableBooksByTime()); 
            //return View(_bookService.GetBooks()); 
        }

        public IActionResult NewBook()
        {
    
            return View(_authorService.GetAuthors());
        }


        [HttpPost]
        public  IActionResult NewBook (NewBookViewModel model )
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AuthError = "ivyko klaida";
                return RedirectToAction("Index", "Auth");
            }

            Book myNewBook = new Book
            {
                Title = model.Title,
                Author = _authorService.GetAuthorById(model.AuthorId)
            };

            _bookService.CreateBook(myNewBook);

            return RedirectToAction("Index");
        }
    }
}
