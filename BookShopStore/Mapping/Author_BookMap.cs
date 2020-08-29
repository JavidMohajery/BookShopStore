using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Mapping
{
    public class Author_BookMap : IEntityTypeConfiguration<Author_Book>
    {
        public void Configure(EntityTypeBuilder<Author_Book> builder)
        {
            builder.HasKey(c => new { c.AuthorId, c.BookId });
            builder.HasOne(c => c.Book).WithMany(c => c.Author_Books).HasForeignKey(c => c.BookId);
            builder.HasOne(c => c.Author).WithMany(c => c.Author_Books).HasForeignKey(c => c.AuthorId);
        }
    }
}
