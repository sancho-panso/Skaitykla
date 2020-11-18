using Microsoft.AspNetCore.Mvc;
using Skaitykla._Domain;
using Skaitykla.MVC.Models;
using Skaitykla.Services.Interfaces;
using System.Collections.Generic;

namespace Skaitykla.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowBookController : Controller
    {
        private readonly ILendingService _lendingService;
        private readonly IUserService _userService;

        public BorrowBookController(ILendingService lendingService, IUserService userService)
        {
            _lendingService = lendingService;
            _userService = userService;
        }

        // POST: api/BorrowBook
        [HttpPost]
        public ActionResult Post([FromBody] BorrowViewModel model)
        {
            if (ModelState.IsValid && _lendingService.IsBookAvailable(model.Id))
            {
                User userWhoWantsToBorrowBook = _userService.GetUserById(2);
                _lendingService.BorrowBook(model.Id, userWhoWantsToBorrowBook);
                return Ok();
            }
            return Accepted();
        }
    }
}
