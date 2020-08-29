using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopStore.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.OrderStatus).WithMany(c => c.Orders).HasForeignKey(c => c.OrderStatusId);
            builder.HasOne(c => c.Customer).WithMany(c => c.Orders).HasForeignKey(c => c.CustomerId);
        }
    }
}
