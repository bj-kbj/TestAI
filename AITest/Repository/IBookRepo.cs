using AITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITest.Repository
{
    public interface IBookRepo
    {
        void AddNewBook(Book book);
        Book GetBooks(Guid id);
        List<Book> GetBooks();
    }
}
