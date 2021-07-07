using System.Collections.Generic;

namespace Bookish.DbModels
{
    public class AuthorDbModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookDbModel> Books { get; set; }
        

    }


}