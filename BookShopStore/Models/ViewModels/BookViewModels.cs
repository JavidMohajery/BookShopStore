using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models.ViewModels
{
    public class BooksCreateViewModel
    {
        public BooksCreateViewModel()
        {

        }
        public BooksCreateViewModel(IEnumerable<TreeViewCategory> categories)
        {
            Categories = categories;
        }
        
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "خلاصه")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "موجودی")]
        public int Stock { get; set; }
        public string File { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "زبان")]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "ناشر")]
        public int PublisherId { get; set; }
        [Display(Name = "تعداد صفحات")]
        public int NumOfPages { get; set; }
        [Display(Name = "وزن")]
        public short Weight { get; set; }
        [Display(Name = "شابک")]
        public string ISBN { get; set; }
        [Display(Name = "این کتاب روی سایت منتشر شود")]
        public bool IsPublished { get; set; }
        [Display(Name = "سال انتشار")]
        public int PublishYear { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "نویسندگان")]
        public int[] AuthorIds { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "مترجمان")]
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
