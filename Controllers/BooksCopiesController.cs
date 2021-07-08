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
    [Route("/[controller]/{action=CopiesCatalogue}")]
    public class BooksCopiesController : Controller
    {

        public IActionResult Copy()
        {
            return View(new BookCopyViewModel());
        }
        
        public IActionResult CopiesCatalogue()
        {
            var catalogue = new CopiesCatalogueViewModel
            {
                Copies = new List<BookCopyViewModel>
                {
                    new BookCopyViewModel
                    {
                        Title = "Dune",
                        Status = "Available"
                    }
                }
            };

            return View(catalogue);
        }
    }
}

