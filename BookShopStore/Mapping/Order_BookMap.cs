using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopStore.Mapping
{
    public class Order_BookMap : IEntityTypeConfiguration<Order_Book>
    {
        public void Configure(EntityTypeBuilder<Order_Book> builder)
        {
            builder.HasKey(c => new { c.BookId, c.OrderId });
            builder.HasOne(c => c.Book).WithMany(c => c.Orders).HasForeignKey(c => c.BookId);
            builder.HasOne(c => c.Order).WithMany(c => c.Books).HasForeignKey(c => c.OrderId);
        }
    }
}
