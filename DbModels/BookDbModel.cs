using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.DbModels
{
    [Table("Books")]
    public class BookDbModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? YearPublished { get; set; }
        public string Isbn { get; set; }
        public List<BookCopyDbModel> Copies { get; set; } 
        public List<AuthorDbModel> Authors { get; set; }
    }

}