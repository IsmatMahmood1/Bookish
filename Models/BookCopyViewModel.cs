using Bookish.DbModels;
using System;

namespace Bookish.Models
{
    public class BookCopyViewModel
    {
        public int Id { get; set; }
        public BookViewModel Book { get; set; }
        public BookCopyStatusEnum.BookCopyStatus Status { get; set; }
        
        
        public BookCopyViewModel(BookCopyDbModel bookCopy)
        {

            Id = bookCopy.Id;
            Book = new BookViewModel(bookCopy.Book);
            Status = bookCopy.Status;
        }
    }
}
