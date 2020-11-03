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
            var categories = _booksRepository.GetAllBooksCategory();
            ViewBag.LanguageId = new SelectList(_context.Languages, nameof(Language.Id), nameof(Language.LanguageName));
            ViewBag.PublisherId = new SelectList(_context.Publishers, nameof(Publisher.Id), nameof(Publisher.Name));
            ViewBag.AuthorId = new SelectList(_context.Authors.Select(a => new AuthorViewModel { Id = a.Id, FullName = a.FirstName + " " + a.LastName }), nameof(AuthorViewModel.Id), nameof(AuthorViewModel.FullName));
            ViewBag.TrnslatorId = new SelectList(_context.Translators.Select(t => new TranslatorViewModel { Id = t.Id, FullName = t.Name + " " + t.Family }), nameof(TranslatorViewModel.Id), nameof(TranslatorViewModel.FullName));

            BooksCreateViewModel viewModel = new BooksCreateViewModel(categories);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BooksCreateViewModel viewModel)
        {
            List<Author_Book> auther_books = new List<Author_Book>();
            List<Book_Translator> book_Translators = new List<Book_Translator>();
            List<Book_Category> book_Categories = new List<Book_Category>();
            if (ModelState.IsValid)
            {
                DateTime? publishDate = null;
                if (viewModel.IsPublished) publishDate = DateTime.Now;
                Book book = new Book
                {
                    Delete = false,
                    ISBN = viewModel.ISBN,
                    IsPublished = viewModel.IsPublished,
                    NumOfPages = viewModel.NumOfPages,
                    Stock = viewModel.Stock,
                    Price = viewModel.Price,
                    LanguageId = (int)viewModel.LanguageId,
                    Summary = viewModel.Summary,
                    Title = viewModel.Title,
                    PublishYear = viewModel.PublishYear,
                    PublishDate = publishDate,
                    Weight = viewModel.Weight,
                    PublisherId = (int)viewModel.PublisherId
                };
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                if (viewModel.AuthorIds != null)
                {
                    for (int i = 0; i < viewModel.AuthorIds.Length; i++)
                    {
                        Author_Book author_Book = new Author_Book
                        {
                            BookId = book.Id,
                            AuthorId = viewModel.AuthorIds[i]
                        };
                        auther_books.Add(author_Book);
                    }
                    await _context.Author_Books.AddRangeAsync(auther_books);
                }

                if (viewModel.TranslatorIds != null)
                {
                    for (int i = 0; i < viewModel.TranslatorIds.Length; i++)
                    {
                        Book_Translator book_Translator = new Book_Translator
                        {
                            BookId = book.Id,
                            TranslatorId = viewModel.TranslatorIds[i]
                        };
                        book_Translators.Add(book_Translator);
                    }
                    await _context.Book_Translators.AddRangeAsync(book_Translators);
                }
                if (viewModel.CategoryIds != null)
                {
                    for (int i = 0; i < viewModel.CategoryIds.Length; i++)
                    {
                        Book_Category book_Category = new Book_Category
                        {
                            BookId = book.Id,
                            CategoryId = viewModel.CategoryIds[i]
                        };
                        book_Categories.Add(book_Category);
                    }
                    await _context.Book_Categories.AddRangeAsync(book_Categories);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                var categories = _booksRepository.GetAllBooksCategory();
                ViewBag.LanguageId = new SelectList(_context.Languages, nameof(Language.Id), nameof(Language.LanguageName));
                ViewBag.PublisherId = new SelectList(_context.Publishers, nameof(Publisher.Id), nameof(Publisher.Name));
                ViewBag.AuthorId = new SelectList(_context.Authors.Select(a => new AuthorViewModel { Id = a.Id, FullName = a.FirstName + " " + a.LastName }), nameof(AuthorViewModel.Id), nameof(AuthorViewModel.FullName));
                ViewBag.TrnslatorId = new SelectList(_context.Translators.Select(t => new TranslatorViewModel { Id = t.Id, FullName = t.Name + " " + t.Family }), nameof(TranslatorViewModel.Id), nameof(TranslatorViewModel.FullName));
                viewModel.Categories = _booksRepository.GetAllBooksCategory();
                return View(viewModel);
            }

        }
    }
}