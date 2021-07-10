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
        BookDbModel GetBookById(int id);

        void AddBook(AddBookViewModel addBookViewModel);
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
            var books = _context.Books
                .Include(book => book.Authors)
                .Include(book => book.Copies)
                .ToList();

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

        public void AddBook(AddBookViewModel addBookViewModel)
        {
            var author = _context.Authors.SingleOrDefault(author => author.FirstName == addBookViewModel.AuthorFirstName
            && author.LastName == addBookViewModel.AuthorLastName)
                ?? new AuthorDbModel()
                {
                    FirstName = addBookViewModel.AuthorFirstName,
                    LastName = addBookViewModel.AuthorLastName
                };

            var copies = new List<BookCopyDbModel>();
            for (var i = 0; i < addBookViewModel.NumberOfCopies; i++)
            {
                copies.Add (new BookCopyDbModel());
            };

            var newBook = new BookDbModel()
            {
                Title = addBookViewModel.Title,
                YearPublished = addBookViewModel.YearPublished,
                Isbn = addBookViewModel.Isbn,
                Authors = new List<AuthorDbModel>{author},
                Copies = copies
            };
            _context.Books.Add(newBook);
            
            _context.SaveChanges();
        }
    }
}
