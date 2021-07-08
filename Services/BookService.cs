using Bookish.DbModels;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookish.Services
{
    public interface IBookService 
    {
        List<BookDbModel> GetBooks();
        List<AuthorDbModel> GetAuthors();
        //List<BookCopyDbModel> GetCopies();
        //List<BorrowerHistoryDbModel> GetBorrowerHistory();
    }
    
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService()
        {
            _context = new LibraryContext();
        }

        public List<BookDbModel> GetBooks()
        {
            var books = _context.Books.ToList();

            return books;
        }

        public List<AuthorDbModel> GetAuthors()
        {
            var authors = _context.Authors.ToList();

            return authors;
        }

        public BookViewModel GetBookView(int id)
        {
            var bookView = new BookViewModel();
            var book = _context.Books
                .Include(book => book.Authors)
                .Single(b => b.Id == id);
            var authorsString = "";
            foreach (var a in book.Authors)
            {
                authorsString += $"{a.FirstName} {a.LastName}, ";
            }

            bookView.Id = id;
            bookView.Title = book.Title;
            //bookView.Author = "";
            bookView.Author = authorsString;
            bookView.YearPublished = book.YearPublished;
            bookView.Isbn = book.Isbn;

            return bookView;

    }
    }
}
