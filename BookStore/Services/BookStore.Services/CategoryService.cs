namespace BookStore.Services
{
    using System;
    using System.Linq;
    using BookStore.Data.Repositories;
    using BookStore.Models;
    using BookStore.Services.Contracts;

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(c => c.Name); ;
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public Category GetByName(string name)
        {
            return this.categories.All().FirstOrDefault(x => x.Name == name);
        }

        public int Create(string name)
        {
            var newCategory = new Category
            {
                Name = name
            };

            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory.Id;
        }
    }
}
