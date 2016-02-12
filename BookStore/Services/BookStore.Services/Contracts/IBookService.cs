namespace BookStore.Services.Contracts
{
    using System.Linq;
    using BookStore.Models;

    public interface IBookService
    {
        IQueryable<Book> GetAll();

        IQueryable<Book> GetById(int bookId);

        int AddBook(string title, string author, string description, string isbn, decimal price, string bookImageUrl, int categoryId, string userId);
    }
}
