using static Bookish.DbModels.BookStatusEnum;

namespace Bookish.DbModels
{
    public partial class BookCopyDbModel
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDbModel Book { get; set; }
        public BookStatus Status { get; set; }

    }


}