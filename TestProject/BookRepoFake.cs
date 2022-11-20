using AITest.Models;
using AITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    public class BookRepoFake: IBookRepo
    {
        private readonly List<Book> _books;
        public BookRepoFake()
        {
            _books = new List<Book>()
            {
                new Book() { Id = new Guid("947251BA-1110-415C-B1F3-3A392AC5EB68"),
                    Name = "DCT", AuthorName="Brooks"},
                
                
            };
        }

        public void AddNewBook(Book book)
        {
            book = new Book()
            {
                Id = new Guid("947251BA-1110-415C-B1F3-3A392AC5EB88"),
                Name = "KDCT",
                AuthorName = "BrooksYupo"
            };
            _books.Add(book);

        }

        public Book GetBooks(Guid id)
        {
            var res = _books.Where(x => x.Id == id).FirstOrDefault();
           return res;
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
    }
}
