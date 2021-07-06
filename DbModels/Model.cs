using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<BookCopyDbModel> BookCopys { get; set; }
        public DbSet<MemberDbModel> Members { get; set; }
        public DbSet<BorrowerHistoryDbModel> BorrowerHistory {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BookishDB;Trusted_Connection=True;");
        }

    }

    public class BookDbModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public string Isbn { get; set; }
    }

    public class BookCopyDbModel
    {
        public int BookCopyId { get; set; }
        public int BookId { get; set; }
        public string Status { get; set; }
    }

    public class AuthorDbModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class MemberDbModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class BorrowerHistoryDbModel
    {
        public int BorrowerHistoryId { get; set; }
        public int MemberId { get; set; }
        public int BookCopyId { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpectedReturn { get; set; }
        public DateTime DateReturned { get; set; }

    }


}