using CraftIQ.Inventory.Core.Entites;
using CraftIQ.REPR.Endpoints.Categories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace CraftIQ.REPR.Endpoints.Categories
{
    public class DeleteCategory(IRepository<Category> repository) : EndpointsAsync.WithRequest<DeleteCategoryRequest>.WithActionResult<DeleteCategoryResponse>
    {
        private readonly IRepository<Category> _repository = repository;
        [HttpDelete(Routes.Routes.CategoriesRoutes.Delete)]
        public override async Task<ActionResult<DeleteCategoryResponse>> HandleAsync(
              [FromRoute] DeleteCategoryRequest request,
              CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Request cannot be null", StatusCodes.Status400BadRequest);
            }

            // 1. إضافة await لاستخراج الـ Category بدلاً من الـ Task
            var category = await _repository.GetByIdAsync(request.CategoryId, cancellationToken);
            if (category == null)
            {
                throw new ResultException("Category not found", StatusCodes.Status404NotFound);
            }

            // 2. إضافة await لعملية الحذف
            await _repository.DeleteAsync(category, cancellationToken);

            // 3. إرجاع النتيجة مباشرة باستخدام Ok
            return Ok(new DeleteCategoryResponse(true));
        }
    }
}
