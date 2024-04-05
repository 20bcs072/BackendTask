using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.Models;

namespace product.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Authors>
    {      
        public void Configure(EntityTypeBuilder<Authors> builder)
        {
            builder.HasKey(c=>c.AuthorID);
            builder.Property(e=>e.AuthorID)
            .HasColumnName("AuthorID")
            .HasColumnType("int")
            .IsRequired();

             builder.Property(e=>e.AuthorName)
            .HasColumnName("AuthorName")
            .HasColumnType("varchar(20)")
            .IsRequired();

           builder.HasMany<Book> (c=> c.books).WithOne(c=> c.authors).HasForeignKey(c=>c.AuthorID);
        }

    }
}