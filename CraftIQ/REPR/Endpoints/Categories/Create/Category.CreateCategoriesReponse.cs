namespace CraftIQ.REPR.Endpoints.Categories.Create
{
    public class CreateCategoriesRepsonse
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public CreateCategoriesRepsonse(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
