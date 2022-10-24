using BookStoreAPI.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreAPI.DataAccess
{
    public class BookStoreConfig:IEntityTypeConfiguration<Book> 
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.AuthorName).HasDefaultValue("Anee Reeds");
            builder.Ignore(x => x.HiddenKey);
        }
    }
}
