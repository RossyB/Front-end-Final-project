namespace BookStore.Api.Models
{
    using BookStore.Api.Infrastructure.Mappings;
    using BookStore.Models;

    public class CategoryResponseModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}