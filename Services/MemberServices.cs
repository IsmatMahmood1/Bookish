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
        MemberDbModel GetMemberById(int id);
        void AddMember(AddMemberViewModel addMemberViewModel);
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

        public MemberDbModel GetMemberById(int id)
        {

            var member = _context.Members.Single(b => b.Id == id);

            return member;
        }

        public void AddMember(AddMemberViewModel addMemberViewModel)
        {
            var newMember = new MemberDbModel()
            {
                FirstName = addMemberViewModel.FirstName,
                LastName = addMemberViewModel.LastName,
                ActiveStatus = addMemberViewModel.ActiveStatus
            };
            _context.Members.Add(newMember);
            _context.SaveChanges();
        
        }
    }
}
