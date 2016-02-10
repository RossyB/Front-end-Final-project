namespace BookStore.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using BookStore.Api.Models;
    using BookStore.Services.Contracts;

    public class CategoriesController : ApiController
    {
        private ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IHttpActionResult Get()
        {
            var categories = this
                .categories
                .GetAll()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(categories);
        }

        [Authorize]
        public IHttpActionResult Post(GreateCategoryRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                if (model == null)
                {
                    return this.BadRequest("Category name cannot be empty!");
                }

                return this.BadRequest(this.ModelState);
            }

            var createdCategory = this.categories.Create(model.Name);

            return this.Ok(createdCategory);
        }
    }
}
