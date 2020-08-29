using BookShopStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopStore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentCategoryId);
            builder.HasData(
                new Category { Id = 1, CategoryName = "هنر" },
                new Category { Id = 2, CategoryName = "عمومی" },
                new Category { Id = 3, CategoryName = "دانشگاهی" }
                );
        }
    }
}
