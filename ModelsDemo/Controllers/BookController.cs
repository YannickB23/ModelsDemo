using Microsoft.AspNetCore.Mvc;
using ModelsDemo.Models;
using ModelsDemo.Repository;
using ModelsDemo.ViewModels;
using System;

namespace ModelsDemo.Controllers
{
    public class BookController : Controller
    {
        //private readonly BookRepository _bookRepository = null;
        BookRepository _bookRepository = new BookRepository();

        [HttpGet]
        public IActionResult Index()
        {
            Book book = new Book();
            book.Id = 1;
            book.Title = "Mvc Core";
            book.Author = "John Doe";
            book.YearPublished = 2020;
            book.Pages = 380;

            Author author = new Author();
            author.Id = 25;
            author.FirstName = "John";
            author.LastName = "Doe";

            AuthorBook authorBook = new AuthorBook();
            authorBook.Book = book;
            authorBook.Author = author;

            //ViewBag.Book = book;

            return View(authorBook);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return View("GetAllBooks", _bookRepository.Database);
        }

        public IActionResult GetUpdatedList()
        {
            var books = _bookRepository.GetUpdatedList();
            return View("GetUpdatedList", _bookRepository.Database);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetDetail(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.EditBook(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book modBook)
        {
            var newBook = _bookRepository.UpdateBook(modBook);
            return View("GetAllBooks", _bookRepository.Database);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetDetail(id);
            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
            return View("GetAllBooks", _bookRepository.Database);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return View("GetUpdatedList", _bookRepository.Database);
            }
            else
            {
                throw new NotImplementedException("One of more field(s) are empty");
            }
        }


        #region HttpGet vs HttpPost
        [HttpGet]
        public IActionResult Dummy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dummy(string personName)
        {
            return View();
        }
        #endregion
    }
}
