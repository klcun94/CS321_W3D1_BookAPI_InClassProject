using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W3D1_BookAPI_InClassProject.Data;
using CS321_W3D1_BookAPI_InClassProject.Models;

namespace CS321_W3D1_BookAPI_InClassProject.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public void Delete(Book deletedBook)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(x => x.Id == deletedBook.Id);
            if (currentBook == null) return;
            _bookContext.Books.Remove(deletedBook);
            _bookContext.SaveChanges();
        }

        public Book Get(int bookId)
        {
            var book = _bookContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null) return null;
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books.ToList();
        }

        private int _nextId = 3;
        public Book Post(Book newBook)
        {
            newBook.Id = _nextId++;
            _bookContext.Books.Add(newBook);
            return newBook;
        }

        public Book Update(Book updatedBook)
        {
            Book currentBook = _bookContext.Books.FirstOrDefault(x => x.Id == updatedBook.Id);
            if (currentBook == null) return null;
            _bookContext.Entry(currentBook).CurrentValues.SetValues(updatedBook);
            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }
    }
}
