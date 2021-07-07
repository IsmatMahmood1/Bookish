namespace Bookish.DbModels
{
    public class BookCopyDbModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDbModel Book { get; set; }
        public string Status { get; set; }
    }


}