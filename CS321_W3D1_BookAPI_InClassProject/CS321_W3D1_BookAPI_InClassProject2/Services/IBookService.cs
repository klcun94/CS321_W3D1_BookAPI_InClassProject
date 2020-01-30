using System;
using System.Collections.Generic;
using CS321_W3D1_BookAPI_InClassProject.Models;

namespace CS321_W3D1_BookAPI_InClassProject.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book Get(int bookId);
        Book Post(Book newBook);
        Book Update(Book updatedBook);
        void Delete(Book deletedBook);
    }
}
