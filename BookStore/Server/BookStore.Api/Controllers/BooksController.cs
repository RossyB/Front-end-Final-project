using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using BookStore.Api.Models;
using BookStore.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace BookStore.Api.Controllers
{
    public class BooksController : ApiController
    {
        private IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        public IHttpActionResult Get()
        {
            var result = this.books
                .GetAll()
                .ProjectTo<BookDetailsResponseModel>()
                .OrderBy(b => b.AddedOn)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.books
                .GetById(id)
                .ProjectTo<BookDetailsResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(AddBookRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentUserId = User.Identity.GetUserId();

            var newBookId = this.books.AddBook(
                model.Title,
                model.Author,
                model.Description,
                model.Isbn,
                model.Price,
                model.BookImageUrl,
                model.CategoryId,
                currentUserId
                );

            return this.Ok(newBookId);
        }
    }
}
