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
        public class ProductRoutes
        {
            public const string baseUrl = "Products";
            public const string Create = baseUrl + "/Create";
            public const string ReadProductByCategoryId = baseUrl +"/Category"+"/{CategoryId}";

            public const string ReadProductById = baseUrl + "/{ProductID}";

            public const string UpdateProduct = baseUrl + "/{ProductId}";
            public const string UpdateCategoryId = baseUrl + "/{ProductId}/Category/{CategoryId}";
            public const string Delete = baseUrl + "/{ProductId}";
            public const string GetByParentId = baseUrl + "/{CategoryId}/Category/{ProductId}";


        }

    }
}
