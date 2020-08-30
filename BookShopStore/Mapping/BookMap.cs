using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("BookInfo");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.Image).HasColumnType("image");
            builder.HasOne(c => c.Category).WithMany(c => c.Books).HasForeignKey(c => c.CategoryId);
            builder.HasOne(c => c.Language).WithMany(c => c.Books).HasForeignKey(c => c.LanguageId);
            builder.HasOne(c => c.Discount).WithOne(c => c.Book).HasForeignKey<Discount>(c => c.BookId);
            builder.HasOne(c => c.Publisher).WithMany(c => c.Books).HasForeignKey(c => c.PublisherId);
        }
    }
}
