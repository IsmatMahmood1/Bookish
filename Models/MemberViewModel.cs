using Bookish.DbModels;
using System;

namespace Bookish.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ActiveStatus { get; set; }

        public MemberViewModel() { }

        public MemberViewModel(MemberDbModel member)
        {
            Id = member.Id;
            FirstName = member.FirstName;
            LastName = member.LastName;
            ActiveStatus = (member.ActiveStatus)?"Active":"Archived";
        }

    }
}
