using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Services;
using Bookish.DbModels;

namespace Bookish.Controllers
{


    [Route("/[controller]/{action=Catalogue}")]
    public class BooksController : Controller
    {

        private readonly IBookService _bookService;
        
        public BooksController (IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/[controller]/{id}")]
        public IActionResult Book(int id)
        {
            var book = _bookService.GetBookById(id);
            return View(new BookViewModel(book));
        }
        
        [HttpGet]
        public IActionResult Catalogue()
        {
     
            var booksInDb = _bookService.GetBooks();
            var books = booksInDb.Select(book => new BookViewModel(book)).ToList();
            var catalogue = new CatalogueViewModel
            {
                Books = books
            };
            return View(catalogue);
        }

        //public IActionResult Copy()
        //{
        //    return View(new BookCopyViewModel(BookCopyDbModel bookCopy);
        //}

        //public IActionResult CopiesCatalogue()
        //{
        
        //    return View(new BookViewModel(_bookService.GetBookById(1)));
        //}


        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult AddBook(AddBookViewModel addBookViewModel)
        {
            _bookService.AddBook(addBookViewModel);
            return RedirectToAction("Catalogue");
            
        }
    }
}

