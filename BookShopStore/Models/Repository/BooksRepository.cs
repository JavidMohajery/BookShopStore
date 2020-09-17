using BookShopStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models.Repository
{
    public class BooksRepository
    {
        private readonly BookshopDbContext _dbContext;
        public BooksRepository(BookshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BindSubcategories(TreeViewCategory category)
        {
            var subCategories = _dbContext.Categories.Where(c => c.ParentCategoryId == category.Id).Select(c => new TreeViewCategory { Id = c.Id, Name = c.CategoryName}).ToList();

            foreach (var item in subCategories)
            {
                BindSubcategories(item);
                category.SubCategories.Add(item);
            }
        }
    }
}
