using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Mapping
{
    public class Book_TranslatorMap : IEntityTypeConfiguration<Book_Translator>
    {
        public void Configure(EntityTypeBuilder<Book_Translator> builder)
        {
            builder.HasKey(c => new { c.BookId, c.TranslatorId });
            builder.HasOne(c => c.Book).WithMany(c => c.Book_Translators).HasForeignKey(c => c.BookId);
            builder.HasOne(c => c.Translator).WithMany(c => c.Book_Translators).HasForeignKey(c => c.TranslatorId);
        }
    }
}
