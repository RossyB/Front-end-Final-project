namespace BookStore.Services
{
    using System;
    using System.Linq;
    using BookStore.Data.Repositories;
    using BookStore.Models;
    using BookStore.Services.Contracts;

    public class BookService: IBookService
    {
        private IRepository<Book> books;
        private IRepository<User> users;

        public BookService(IRepository<Book> books, IRepository<User> users)
        {
            this.books = books;
            this.users = users;
        }

        public IQueryable<Book> GetAll()
        {
            return this.books.All()
                .OrderBy(c => c.Title);
        }

        public IQueryable<Book> GetById(int bookId)
        {
            return this.books
                .All()
                .Where(b => b.Id == bookId);

        }

        public int AddBook(string title, string author, string description, string isbn, string price, string bookImageUrl, int categoryId, string userId)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var newBook = new Book()
            {
                Title = title,
                Author = author,
                Description = description,
                Isbn = isbn,
                Price = decimal.Parse(price),
                BookImageUrl = bookImageUrl,
                AddedOn = DateTime.UtcNow,
                CategoryId = categoryId,
                OwnerId = userId,
            };

            this.books.Add(newBook);
            this.books.SaveChanges();

            return newBook.Id;
        }
    }
}
