using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bookish.DbModels
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
            optionsBuilder.UseSqlServer(@"Server=.\localhost:5000;Database=BookishDB;Trusted_Connection=True;");
        }

    }
    
    [Table("Books")]
    public class BookDbModel
    {
        public int Id { get; }
        public string Title { get; set; }
        public int? YearPublished { get; set; }
        public string Isbn { get; set; }
        public List<BookCopyDbModel> Copies { get; set; } 
        public List<AuthorDbModel> Authors { get; set; }
    }

    public class BookCopyDbModel
    {
        public int Id { get; }
        public int BookId { get; set; }
        public BookDbModel Book { get; set; }
        public string Status { get; set; }
    }

    public class AuthorDbModel
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookDbModel> Books { get; set; }

    }

    public class MemberDbModel
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class BorrowerHistoryDbModel
    {
        public int Id { get; }
        public int MemberId { get; set; }
        public MemberDbModel Member { get; set; }
        public int BookCopyId { get; set; }
        public BookCopyDbModel Copy { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpectedReturn { get; set; }
        public DateTime? DateReturned { get; set; }

    }


}