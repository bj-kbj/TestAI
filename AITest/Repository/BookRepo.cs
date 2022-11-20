using AITest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITest.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly IConfiguration _configuration;
        public BookRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void AddNewBook(Book book)
        {
            var books = new List<Book>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "insert into dbo.tbl_Books(id, name, authorName)";
                query += " VALUES (@Id, @Name, @AuthorName)";
                connection.Open();
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Id", Guid.NewGuid());
                myCommand.Parameters.AddWithValue("@Name", book.Name);
                myCommand.Parameters.AddWithValue("@AuthorName", book.AuthorName);

                myCommand.ExecuteNonQuery();
            }
        }

        public Book GetBooks(Guid id)
        {
            var books = new Book();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "SELECT Id, Name, AuthorName FROM tbl_Books where id=" + "'" + id + "'";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books = new Book()
                    {
                        Id = (Guid)reader["Id"],
                        Name = reader["Name"].ToString(),
                        AuthorName = reader["AuthorName"].ToString(),

                    };
                }
            }
            return books;
        }

        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "SELECT Id, Name, AuthorName FROM tbl_Books";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Book()
                    {
                        Id = (Guid)reader["Id"],
                        Name = reader["Name"].ToString(),
                        AuthorName = reader["AuthorName"].ToString(),

                    };
                    books.Add(book);
                }
            }
            return books;
        }
    }
}
