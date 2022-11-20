using AITest.Controllers;
using AITest.Models;
using AITest.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject
{
    public class BookControllerTests
    {
        private readonly BookController _controller;
        private readonly IBookRepo _service;
        public BookControllerTests()
        {
            _service = new BookRepoFake();
            _controller = new BookController(_service);
        }

        [Fact]
        public void GetBooks_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("947251BA-1110-415C-B1F3-3A392AC5EB68");
            // Act
            var okResult = _controller.GetById(testGuid);
            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetById(Guid.NewGuid());
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void AddBook_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Book testItem = new Book()
            {
                Id = new Guid("947251BA-1110-415C-B1F3-3AA92AC5EB68"),
                Name = "ACT",
                AuthorName = "Malan"
            };
            // Act
            var createdResponse = _controller.AddBook(testItem);
            // Assert
            Assert.IsType<OkResult>(createdResponse);
        }
    }
}
