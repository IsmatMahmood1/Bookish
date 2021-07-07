using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;

namespace Bookish.Controllers
{
    [Route("/[controller]/{action=Catalogue}")]
    public class BooksController : Controller
    {

        public IActionResult Book()
        {
            return View(new BookViewModel());
        }
        
        public IActionResult Catalogue()
        {
            var catalogue = new CatalogueViewModel
            {
                Books = new List<BookViewModel>
                {
                    new BookViewModel
                    {
                        Title = "Dune"
                    }
                }
            };

            return View(catalogue);
        }
    }
}

