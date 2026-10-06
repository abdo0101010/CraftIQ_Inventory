using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Categories.Specification;
using CraftIQ.Inventory.Core.Entites.Inventories.Spceification;
using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Core.Entites.Products.Specification;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text;

namespace CraftIQ.Inventory.Services.ProductsImplemention
{
    public class ProductService<TRequest, TResponse>(IRepository<Product> Repo , IRepository<Category> Cateegory, IRepository<Core.Entites.Inventories.Inventory> Inventory) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Category> _Cateegory= Cateegory;

        private readonly IRepository<Product> _Repo = Repo;
        private readonly IRepository<Core.Entites.Inventories.Inventory> _Inventory = Inventory;

        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var oContract = contract as ProductOperationContract;
            if (oContract == null)
                throw new ResultException("Invalid product contract payload.", (int)HttpStatusCode.BadRequest);

            if (oContract.CategoryId == Guid.Empty)
                throw new ResultException("Category ID is required.", (int)HttpStatusCode.BadRequest);
            var OCategory = new Core.Entites.Categories.Specification.ReadByIdSpecification(oContract.CategoryId);
            var category = await _Cateegory.FirstOrDefaultAsync(OCategory);
            if (category == null)
                throw new ResultException($"Category with ID '{oContract.CategoryId}' was not found.", (int)HttpStatusCode.NotFound);
            var existingProductSpec = new Core.Entites.Products.Specification.ReadByIdSpecification(oContract.ProductId);
            var existingProduct = await _Repo.FirstOrDefaultAsync(existingProductSpec);
            if (existingProduct != null)
                throw new ResultException($"Product with ID '{oContract.ProductId}' already exists.", (int)HttpStatusCode.Conflict);

            var oInventory = new Core.Entites.Inventories.Spceification.ReadByIdSpceifecation(oContract.InventoryId);
            var inventory = await _Inventory.FirstOrDefaultAsync(oInventory);
            if (inventory == null)
                throw new ResultException($"Inventory with ID '{oContract.InventoryId}' was not found.", (int)HttpStatusCode.NotFound);

            var oData = new Product(
                oContract.ProductId,
              
                oContract.Name,
                oContract.Description,
                oContract.UnitPrice,
                oContract.Weight,
                oContract.Length,
                oContract.Width,
                oContract.Height,
                oContract.CategoryId,
                oContract.TaxCost,
                oContract.ProfitPerUnit,
                oContract.ProductionCost
            );

            // ربط الفئة المجلوية صراحة بالمنتج لضمان اكتمال الـ Navigation Property
            oData.SetCategory(category);
            oData.SetInventory(inventory);

            var oResult = await _Repo.AddAsync(oData);

            // 3. إرجاع الـ Contract بأمان باستخدام category.CategoryId تجنباً للـ NullReferenceException
            return new ProductContract(
                oResult.ProductId,
                oResult.Inventory.InventoryId, // InventoryId is not set during creation
                oResult.Name,
                oResult.Description,
                oResult.UnitPrice,
                oResult.Weight,
                oResult.Length,
                oResult.Width,
                oResult.Height,
                category.CategoryId, 
                oResult.TaxCost,
                oResult.ProfitPerUnit,
                oResult.ProductionCost
            ) as dynamic;
        }
        public async ValueTask Delete(Guid ContractId)
        {
            var OGetIdSpec = new Core.Entites.Products.Specification.ReadByIdSpecification(ContractId);
            var OData =await _Repo.FirstOrDefaultAsync(OGetIdSpec);
            if (OData == null)
                throw new ResultException("not found Category in a real life to delete", (int)HttpStatusCode.NotFound);

            await _Repo.DeleteAsync(OData);
            
        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var OContract = new Core.Entites.Products.Specification.ReadSpecification();

            var OData = await _Repo.ListAsync(OContract);

            if (OData.Count != 0)
            {
                var OResult = OData.Select(o => new ProductContract(o.ProductId,Guid.Empty, o.Name, o.Description, o.UnitPrice, o.Weight, o.Length, o.Width, o.Height,Guid.Empty, o.TaxCost, o.ProfitPerUnit, o.ProductionCost)).ToList();
                return OResult as dynamic;

            }
            else throw new ResultException("cannot found any products", (int)HttpStatusCode.NotFound);
            


        }

        public async ValueTask<TResponse> GetById(Guid ContractId)
        {
            var oContract = new Core.Entites.Products.Specification.ReadByIdSpecification(ContractId);
            var OData = await _Repo.FirstOrDefaultAsync(oContract);
            if (OData != null)
                return new ProductContract(OData.ProductId,
                                           Guid.Empty,
                                           OData.Name,
                                           OData.Description,
                                           OData.UnitPrice,
                                           OData.Weight, 
                                           OData.Length,
                                           OData.Width,
                                           OData.Height,
                                           Guid.Empty,
                                           OData.TaxCost,
                                           OData.ProfitPerUnit,
                                           OData.ProductionCost) as dynamic;
          
             else throw new ResultException("cannot found any product", (int)HttpStatusCode.NotFound);

        }

        public async ValueTask<List<TResponse>> GetByParentId(Guid parentId)
        {
            var OContract = new ReadProductByCategoryIdSpecification(parentId);
            var oCategoryResult =await _Cateegory.FirstOrDefaultAsync(OContract);
            if (oCategoryResult != null)
            {
                var oProducts = oCategoryResult.Products;
                var OResult = oProducts.Select(p => new ProductContract(p.ProductId,
                                                                    Guid.Empty,
                                                                    p.Name,
                                                                    p.Description,
                                                                    p.UnitPrice,
                                                                    p.Weight,
                                                                    p.Length,
                                                                    p.Width,
                                                                    p.Height,
                                                                   Guid.Empty,
                                                                    p.TaxCost,
                                                                    p.ProfitPerUnit,
                                                                    p.ProductionCost)).ToList();
                return OResult as dynamic;

            }
            else throw new ResultException("not found any products in this category", ((int)HttpStatusCode.NotFound));
        }

        public async ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id)
        {
            var OContract = new ReadSingleProductByCategoryIdSpecification(parentId, id);
            var OData =await _Cateegory.FirstOrDefaultAsync(OContract);
            if (OData != null)
            {
                if (OData.Products == null || OData.Products.Count == 0)
                    throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
                var oProduct = OData.Products.FirstOrDefault();
                var oResult = new ProductContract(
                    oProduct!.ProductId,
                    Guid.Empty,
                    oProduct.Name,
                    oProduct.Description,
                    oProduct.UnitPrice,
                    oProduct.Weight,
                    oProduct.Length,
                    oProduct.Width,
                    oProduct.Height,
                    OData.CategoryId,
                    oProduct.TaxCost,
                    oProduct.ProfitPerUnit,
                    oProduct.ProductionCost
                );
                return oResult as dynamic;

            }
            return default!;

        }

        public async ValueTask Update(TRequest contract, Guid id)
        {
            var OContract = contract as ProductOperationContract;

            var OGetByIdSpec = new Core.Entites.Products.Specification.ReadByIdSpecification(id);
            var OData = await _Repo.FirstOrDefaultAsync(OGetByIdSpec);
            if (OData != null)
            {

                OData.UpdateProduct(OContract); 
                 await _Repo.UpdateAsync(OData);
                
            }
                else throw new ResultException("Cannot update null product", (int)HttpStatusCode.BadRequest);
                
        }

        public async ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            var oReadByIdSpec = new Core.Entites.Products.Specification.ReadByIdSpecification(ContractId);
            var oResult = await _Repo.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult == null)
                throw new ResultException("This product object is not exit", (int)HttpStatusCode.NotFound);

            var oReadParentByIdSpec = new Core.Entites.Categories.Specification.ReadByIdSpecification(parentId);
            var oParentResult = await _Cateegory.FirstOrDefaultAsync(oReadParentByIdSpec);
            if (oParentResult == null)
                throw new ResultException("This category object is not exit", (int)HttpStatusCode.NotFound);

            oResult.SetCategory(oParentResult);
            await _Repo.UpdateAsync(oResult);
        }
    }
}
