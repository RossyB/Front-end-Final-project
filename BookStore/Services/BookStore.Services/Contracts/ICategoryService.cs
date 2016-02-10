namespace BookStore.Services.Contracts
{
    using System.Linq;
    using BookStore.Models;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        Category GetById(int id);

        Category GetByName(string name);

        int Create(string name);
    }
}
