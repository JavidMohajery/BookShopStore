using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models.ViewModels
{
    public class BooksCreateViewModel
    {
        public BooksCreateViewModel(IEnumerable<TreeViewCategory> categories)
        {
            Categories = categories;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string File { get; set; }
        public int LanguageId { get; set; }
        public int PublisherId { get; set; }
        public int NumOfPages { get; set; }
        public short Weight { get; set; }
        public string ISBN { get; set; }
        public bool IsPublished { get; set; }
        public int PublishYear { get; set; }
        public int[] AuthorIds { get; set; }
        public int[] TranslatorIds { get; set; }
        public int[] CategoryIds { get; set; }

        public IEnumerable<TreeViewCategory> Categories { get; set; }
    }
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public class TranslatorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
