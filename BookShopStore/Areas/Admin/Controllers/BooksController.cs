using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopStore.Models;
using BookShopStore.Models.Repository;
using BookShopStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly BookshopDbContext _context;
        private readonly BooksRepository _booksRepository;
        public BooksController(BookshopDbContext context, BooksRepository booksRepository)
        {
            _context = context;
            _booksRepository = booksRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var categories = _context.Categories.Where(c => c.ParentCategoryId == null).Select(c => new TreeViewCategory { Id = c.Id, Name = c.CategoryName }).ToList();
            foreach (var item in categories)
            {
                _booksRepository.BindSubcategories(item);
            }

            ViewBag.LanguageId = new SelectList(_context.Languages, nameof(Language.Id), nameof(Language.LanguageName));
            ViewBag.PublisherId = new SelectList(_context.Publishers, nameof(Publisher.Id), nameof(Publisher.Name));
            ViewBag.AuthorId = new SelectList(_context.Authors.Select(a => new AuthorViewModel { Id = a.Id, FullName = a.FirstName + " " + a.LastName}), nameof(AuthorViewModel.Id), nameof(AuthorViewModel.FullName));
            ViewBag.TrnslatorId = new SelectList(_context.Translators.Select(t => new TranslatorViewModel { Id = t.Id, FullName = t.Name + " " + t.Family}), nameof(TranslatorViewModel.Id), nameof(TranslatorViewModel.FullName));

            BooksCreateViewModel viewModel = new BooksCreateViewModel(categories);
            return View(viewModel);
        }
    }
}