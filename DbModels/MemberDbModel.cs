using System.Collections.Generic;

namespace Bookish.DbModels
{
    public class MemberDbModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ActiveStatus { get; set; }
        public List<BorrowerHistoryDbModel> BorrowerHistories { get; set; }

    }


}