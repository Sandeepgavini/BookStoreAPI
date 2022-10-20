using BookStoreAPI.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.DataAccess
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Ignore(b => b.HiddenKey);
            modelBuilder.Entity<Book>().Property(x => x.AuthorName).HasDefaultValue("Anee Reeds");
            modelBuilder.Entity<Book>().Ignore(x => x.HiddenKey);
        }
    }
}
