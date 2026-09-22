namespace CraftIQ.REPR.Endpoints.Routes
{
    public static class Routes
    {
        public class CategoriesRoutes
        {
            public const string baseUrl = "Categories";
            public const string Create = baseUrl + "/Create";
            public const string Delete = baseUrl + "/{CategoryId}";
            public const string ReadCategoryByCategoryId = baseUrl + "/{CategoryID}";
            public const string UpdateCategory = baseUrl + "/{CategoryId}";
        }
        
    }
}
