using Bookish.DbModels;
using System;

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
            var authorsString = "";
            foreach (var a in book.Authors)
            {
               authorsString += $"{a.FirstName} {a.LastName}, ";
            }
            var copiesAvailable = 0;
            foreach (var copy in book.Copies)
            {
                if (copy.Status == "Available")
                {
                    copiesAvailable++;
                }
            }
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
