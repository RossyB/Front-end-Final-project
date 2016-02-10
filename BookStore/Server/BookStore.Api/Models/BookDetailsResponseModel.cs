namespace BookStore.Api.Models
{
    using System;
    using AutoMapper;
    using BookStore.Api.Infrastructure.Mappings;
    using BookStore.Models;

    public class BookDetailsResponseModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Isbn { get; set; }

        public Decimal Price { get; set; }

        public string Category { get; set; }

        public string BookImageUrl { get; set; }

        public string AddedOn { get; set; }

        public string Owner { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Book, BookDetailsResponseModel>()
                .ForMember(b => b.Owner, opts => opts.MapFrom(o => o.Owner.UserName))
                .ForMember(b => b.Category, opts => opts.MapFrom(c => c.Category.Name))
                .ForMember(b => b.AddedOn, opts => opts.MapFrom(d => d.AddedOn));
        }
    }
}