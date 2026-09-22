namespace CraftIQ.REPR.Endpoints.Categories.Delete
{
    public class DeleteCategoryResponse
    {
        public bool IsDeleted { get; set; }

        public DeleteCategoryResponse(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
