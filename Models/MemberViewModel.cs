using System;

namespace Bookish.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public bool ActiveStatus { get; set; }

    }
}
