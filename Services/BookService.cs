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

        public BookDbModel GetBookById(int id)
        {

            var book = _context.Books
                .Include(book => book.Authors)
                .Include(book => book.Copies)
                .Single(b => b.Id == id);

            return book;
        }
    }
}
