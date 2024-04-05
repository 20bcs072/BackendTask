using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.Models;

namespace product.Configuration
{
public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(c=>c.Id);
            builder.Property(e=>e.Id)
            .HasColumnName("ID")
            .HasColumnType("int")
           
            .IsRequired();

            builder.Property(e=>e.Title)
            .HasColumnName("Title")
            .HasColumnType("varchar(20)")
            .IsRequired();

            builder.Property(e=>e.Price)
            .HasColumnName("Price")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(e=>e.Author)
            .HasColumnName("Author")
            .HasColumnType("varchar(15)")
            .IsRequired();

            builder.Property(e=>e.Edition)
            .HasColumnName("Edition")
            .HasColumnType("int")
            .IsRequired();

            
        builder.Property(e => e.PublishedDate)
       .HasColumnName("PublishedDate")
       .HasColumnType("DATE")
       .IsRequired();


            builder.Property(e=>e.RowVer)
            .IsRowVersion();
 

        
        }
    }
}