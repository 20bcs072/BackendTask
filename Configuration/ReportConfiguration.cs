using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.Models;

namespace product.Configuration
{
public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
        builder.HasKey(c=>c.ReportID);
            builder.Property(e=>e.ReportID)
            .HasColumnName("ReportID")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(e=>e.fromDate)
            .HasColumnName("fromDate")
            .HasColumnType("DATE")
            .IsRequired();

            builder.Property(e=>e.toDate)
            .HasColumnName("toDate")
            .HasColumnType("DATE")
            .IsRequired();

            builder.Property(e=>e.ReportStatus)
            .HasColumnName("ReportStatus")
            .HasColumnType("varchar(15)")
            .IsRequired();

        
        }
    }
}