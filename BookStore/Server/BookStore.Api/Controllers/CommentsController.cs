using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Api.Models;
using BookStore.Models;
using Microsoft.AspNet.Identity;

namespace BookStore.Api.Controllers
{
    public class CommentsController : ApiController
    {
        public IHttpActionResult Create(int id, AddCommentModel model)
        {
            var userId = this.User.Identity.GetUserId();

            var comment = new Comment
            {
                Content = model.Content,
                BookId = model.Id,
                UserId = userId
            };
            return this.Ok(comment);
        }

    }
}
