using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopStore.Models;
using BookShopStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly BookshopDbContext _context;

        public BooksController(BookshopDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(_context.Languages, nameof(Language.Id), nameof(Language.LanguageName));
            ViewBag.PublisherId = new SelectList(_context.Publishers, nameof(Publisher.Id), nameof(Publisher.Name));
            ViewBag.AuthorId = new SelectList(_context.Authors.Select(a => new AuthorViewModel { Id = a.Id, FullName = a.FirstName + " " + a.LastName}), nameof(AuthorViewModel.Id), nameof(AuthorViewModel.FullName));
            ViewBag.TrnslatorId = new SelectList(_context.Translators.Select(t => new TranslatorViewModel { Id = t.Id, FullName = t.Name + " " + t.Family}), nameof(TranslatorViewModel.Id), nameof(TranslatorViewModel.FullName));
            return View();
        }
    }
}