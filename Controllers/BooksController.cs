using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Services;

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
            var service = new BookService();
            var booksInDb = service.GetBooks();
            var books = new List<BookViewModel>();
            foreach (var book in booksInDb)
            {
                var newBook = service.GetBookById(book.Id);
                var newBookView = new BookViewModel(newBook);
                books.Add(newBookView);
            }
            var catalogue = new CatalogueViewModel
            {
                Books = books
                
        };
            return View(catalogue);
        }
    }
}

