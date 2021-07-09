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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDbModel>().HasMany(book => book.Authors).WithMany(author => author.Books).UsingEntity(join => join.ToTable("BookAuthors"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=BookishDB;User Id=sa;Password=Password123;");
        }
    }
}