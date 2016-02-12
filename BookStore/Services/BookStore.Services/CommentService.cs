using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Repositories;
using BookStore.Models;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    class CommentService : ICommentService
    {
        private IRepository<Book> books;
        private IRepository<User> users;
        private IRepository<Comment> comments;

        public CommentService(IRepository<Book> books, IRepository<User> users, IRepository<Comment> comments)
        {
            this.books = books;
            this.users = users;
            this.comments = comments;
        }

        public int AddComment(string content, int bookId, string userId)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var newComment = new Comment
            {
                Content = content,
                UserId = userId,
                BookId = bookId,
                CreatedOn = DateTime.UtcNow,
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment.Id;
        }
    }
}
