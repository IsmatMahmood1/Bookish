using Bookish.DbModels;
using System;
using System.Linq;

namespace Bookish.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? YearPublished { get; set; }
        public string Isbn { get; set; }

        public int CopiesInBookish { get; set; }
        public int CopiesAvailable { get; set; }


        public BookViewModel() { }
        
        public BookViewModel(BookDbModel book)
        {
            var authorsString = String.Concat(book.Authors.Select(o => o.FirstName + " " + o.LastName));
        
            var copiesAvailable = book.Copies.Where(copy => copy.Status == "Available").Count();
        
            Id = book.Id;
            Title = book.Title;
            Author = authorsString;
            YearPublished = book.YearPublished;
            Isbn = book.Isbn;
            CopiesInBookish = book.Copies.Count;
            CopiesAvailable = copiesAvailable;
        }

    }
}
