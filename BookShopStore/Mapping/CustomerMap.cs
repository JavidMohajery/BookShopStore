using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasColumnName("FName").HasColumnType("nvarchar(20)");
            builder.Property(c => c.LastName).HasColumnName("LName").HasMaxLength(100);
            builder.Ignore(c => c.Age);
            builder.HasOne(c => c.City1).WithMany(c => c.Customers1).HasForeignKey(c => c.CityId1);
            builder.HasOne(c => c.City2).WithMany(c => c.Customers2).HasForeignKey(c => c.CityId2).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
