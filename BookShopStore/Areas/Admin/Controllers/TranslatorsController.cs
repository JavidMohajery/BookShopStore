using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopStore.Models;
using BookShopStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShopStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TranslatorsController : Controller
    {
        private readonly BookshopDbContext _bookshopDbContext;

        public TranslatorsController(BookshopDbContext bookshopDbContext)
        {
            _bookshopDbContext = bookshopDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _bookshopDbContext.Translators.ToListAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TranslatorCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Translator translator = new Translator { Name = viewModel.Name, Family = viewModel.Family };
                _bookshopDbContext.Translators.Add(translator);
                await _bookshopDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue) return NotFound();
            var translator = await _bookshopDbContext.Translators.SingleOrDefaultAsync(c => c.Id == id);
            if (translator == null) return NotFound();
            return View(translator);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Translator translator)
        {
            if (ModelState.IsValid)
            {
                _bookshopDbContext.Update(translator);
                await _bookshopDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(translator);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Translator translator = await _bookshopDbContext.Translators.SingleOrDefaultAsync(c => c.Id == id);
            if (translator == null) return NotFound();

            return View(translator);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleted(int? id)
        {
            if (id == null) return NotFound();
            Translator translator = await _bookshopDbContext.Translators.SingleOrDefaultAsync(c => c.Id == id);
            if (translator == null) return NotFound();

            _bookshopDbContext.Translators.Remove(translator);
            await _bookshopDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}