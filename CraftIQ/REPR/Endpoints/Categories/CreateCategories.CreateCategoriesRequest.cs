using System.ComponentModel.DataAnnotations;

namespace CraftIQ.REPR.Endpoints.Categories
{
    public class CreateCategoriesRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } 

    }
}
