using Bookish.DbModels;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookish.Services
{
    public interface IMemberService
    {
        List<MemberDbModel> GetMembers();
     }

    public class MemberService : IMemberService
    {
        private readonly LibraryContext _context;

        public MemberService()
        {
            _context = new LibraryContext();
        }

        public List<MemberDbModel> GetMembers()
        {
            var members = _context.Members.ToList();

            return members;
        }

        public MemberDbModel GetMemberById(string firstname)
        {

            var member = _context.Members
                //.Include(book => book.Authors)
                //.Include(book => book.Copies)
                .Single(b => b.FirstName == "Ismat");

            return member;
        }
    }
}
