using static Bookish.DbModels.BookCopyStatusEnum;

namespace Bookish.DbModels
{
    public partial class BookCopyDbModel
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDbModel Book { get; set; }
        public BookCopyStatus Status { get; set; }

        public BookCopyDbModel()
        {

        }

        public BookCopyDbModel(int bookId)
        {
            BookId = bookId;
        }

    }


}