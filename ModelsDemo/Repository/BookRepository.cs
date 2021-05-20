using ModelsDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelsDemo.Repository
{
    public class BookRepository
    {
        private static List<Book> _list = new List<Book>();

        public List<Book> Database
        {
            get { return _list; }
        }

        public List<Book> GetAllBooks()
        {
            return _list = FakeDatabase();
        }

        public List<Book> GetUpdatedList()
        {
            return _list;
        }

        public Book GetDetail(int id)
        {
            var foundedBook = _list.Find(b => b.Id.Equals(id));
            return foundedBook;
        }

        public Book EditBook(int id)
        {
            var foundBook = _list.Find(b => b.Id.Equals(id));
            return foundBook;
        }

        public Book UpdateBook(Book newBook)
        {
            var oldBook = FakeDatabase().FirstOrDefault(b => b.Id.Equals(newBook.Id));
            _list.Remove(oldBook);
            _list.Add(newBook);
            return newBook;
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = _list.Find(b => b.Id.Equals(id));
            _list.Remove(bookToDelete);
            return bookToDelete;
        }

        public Book AddBook(Book book)
        {
            _list.Add(book);
            return (book);
        }

        private List<Book> FakeDatabase()
        {

            _list.Add(new Book() { Id = 01, Title = "Mvc Core", Author = "Jane Doe", YearPublished = 2021, Pages = 425 });
            _list.Add(new Book() { Id = 25, Title = "C#", Author = "John Doe", YearPublished = 2015, Pages = 110 });
            _list.Add(new Book() { Id = 51, Title = "Python", Author = "Jack Foe", YearPublished = 1018, Pages = 342 });
            _list.Add(new Book() { Id = 23, Title = "Angular", Author = "Jacky Foe", YearPublished = 2017, Pages = 841 });
            _list.Add(new Book() { Id = 16, Title = "ZieScherp", Author = "Jana Janssens", YearPublished = 1015, Pages = 125 });
            _list.Add(new Book() { Id = 17, Title = ".NET Core", Author = "John Foe", YearPublished = 2019, Pages = 450 });
            return _list;
        }
    }
}
