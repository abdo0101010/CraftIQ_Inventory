using CraftIQ.Inventory.Core.Entites;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories
{
    public class CreateCategories(IRepository<Category> repository) : EndpointsSync.WithRequest<CreateCategoriesRequest>.WithActionResult<CreateCategoriesRepsonse>
    {
        private readonly IRepository<Category> _repository = repository;
        [HttpPost(Routes.Routes.CategoriesRoutes.Create)]
        public override ActionResult<CreateCategoriesRepsonse> Handle(CreateCategoriesRequest request)
        {
            if(request == null)
            {
                throw new ResultException("Request cannot be null", StatusCodes.Status400BadRequest);
            }
            var response = new Category(request.Name, request.Description);
            _repository.AddAsync(response);


            return Ok(response);
        }
    }
}
