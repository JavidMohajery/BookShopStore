using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Mapping
{
    public class Book_CategoryMap : IEntityTypeConfiguration<Book_Category>
    {
        public void Configure(EntityTypeBuilder<Book_Category> builder)
        {
            builder.HasKey(c => new { c.BookId, c.CategoryId });
            builder.HasOne(c => c.Book).WithMany(c => c.Book_Categories).HasForeignKey(c => c.BookId);
            builder.HasOne(c => c.Category).WithMany(c => c.Book_Categories).HasForeignKey(c => c.CategoryId);
        }
    }
}
