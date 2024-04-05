using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.Models;

namespace product.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           
           builder.HasKey(c=>c.BookID);
            builder.Property(e=>e.BookID)
            .HasColumnName("BookID")
            .HasColumnType("int")
            .IsRequired();

             builder.Property(e=>e.BookName)
            .HasColumnName("BookName")
            .HasColumnType("varchar(20)")
            .IsRequired();

            builder.HasOne<Authors>(c=>c.authors).WithMany(c=>c.books).HasForeignKey(c=>c.AuthorID);
        }

    }
}