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
            public const string ReadProductByCategoryId = baseUrl + "/Category" + "/{CategoryId}";

            public const string ReadProductById = baseUrl + "/{ProductID}";

            public const string UpdateProduct = baseUrl + "/{ProductId}";
            public const string UpdateCategoryId = baseUrl + "/{ProductId}/Category/{CategoryId}";
            public const string Delete = baseUrl + "/{ProductId}";
            public const string GetByParentId = baseUrl + "/{CategoryId}/Category/{ProductId}";


        }
        public class InventoryRoutes
        {
            public const string baseUrl = "Inventories";
            public const string Create = baseUrl + "/Create";
            public const string ReadInventoryById = baseUrl + "/{InventoryId}";
            public const string UpdateInventory = baseUrl + "/{InventoryId}";
            public const string Delete = baseUrl + "/{InventoryId}";

        }
    }
}
