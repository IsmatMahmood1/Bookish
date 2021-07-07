using System;

namespace Bookish.DbModels
{
    public class BorrowerHistoryDbModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MemberDbModel Member { get; set; }
        public int BookCopyId { get; set; }
        public BookCopyDbModel Copy { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpectedReturn { get; set; }
        public DateTime? DateReturned { get; set; }

    }


}