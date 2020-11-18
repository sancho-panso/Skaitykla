using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skaitykla._Domain;
using Skaitykla._EF;
using Skaitykla.MVC.Models;
using Skaitykla.Services;
using Skaitykla.Services.Interfaces;

namespace Skaitykla.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService service, ILogger<AuthorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public ActionResult Index()
        {
          
            return View(_service.GetAuthors());
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(Guid id)
        {
            Author author = _service.GetAuthorById(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _service.CreateAuthor(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError("Fault on Athor create", ex);
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_service.GetAuthorById(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, AuthorViewModel model)
        {
            try
            {
                _service.Edit(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(Guid id)
        {
            Author author = _service.GetAuthorById(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            try
            {

                _service.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } 
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
