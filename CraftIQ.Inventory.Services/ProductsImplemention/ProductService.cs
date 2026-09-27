using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Categories.Specification;
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
    public class ProductService<TRequest, TResponse>(IRepository<Product> Repo , IRepository<Category> Cateegory) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Category> _Cateegory= Cateegory;

        private readonly IRepository<Product> _Repo = Repo;

        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var oContract = contract as ProductOperationContract;
            if (oContract == null)
                throw new ResultException("Cannot add null category ", (int)HttpStatusCode.BadRequest);
            if (oContract.CategoryId == Guid.Empty)
                throw new ResultException("notfounded  category ", (int)HttpStatusCode.BadRequest);


            var OData = new Product(oContract.ProductId, oContract.Name, oContract.Description, oContract.UnitPrice, oContract.Weight, oContract.Length,oContract.Width, oContract.Height, oContract.CategoryId, oContract.TaxCost, oContract.ProfitPerUnit, oContract.ProductionCost);

            var OResult = await _Repo.AddAsync(OData);
            return new ProductContract(OResult.ProductId, OResult.Name, OResult.Description, OResult.UnitPrice, OResult.Weight, OResult.Length, OResult.Width, OResult.Height, OResult.CategoryId, OResult.TaxCost, OResult.ProfitPerUnit, OResult.ProductionCost) as dynamic;
        }

        public async ValueTask Delete(Guid ContractId)
        {
            var OGetIdSpec = new Core.Entites.Products.Specification.ReadByIdSpecification(ContractId);
            var OData =await _Repo.GetByIdAsync(OGetIdSpec);
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
                var OResult = OData.Select(o => new ProductContract(o.ProductId, o.Name, o.Description, o.UnitPrice, o.Weight, o.Length, o.Width, o.Height, o.CategoryId, o.TaxCost, o.ProfitPerUnit, o.ProductionCost));
                return OResult as dynamic;

            }
            else throw new ResultException("cannot found any products", (int)HttpStatusCode.NotFound);
            


        }

        public async ValueTask<TResponse> GetById(Guid ContractId)
        {
            var oContract = new Core.Entites.Products.Specification.ReadByIdSpecification(ContractId);
            var OData = await _Repo.GetByIdAsync(oContract);
            if(OData!=null)
                return new ProductContract(OData.ProductId,
                                           OData.Name,
                                           OData.Description,
                                           OData.UnitPrice, 
                                           OData.Weight, OData.Length, 
                                           OData.Width, OData.Height,
                                           OData.CategoryId,
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
                                                                    p.Name,
                                                                    p.Description,
                                                                    p.UnitPrice,
                                                                    p.Weight,
                                                                    p.Length,
                                                                    p.Width,
                                                                    p.Height,
                                                                    p.CategoryId,
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
                if (OContract != null)
                {
                    OData.UpdateProduct(OContract);
                    if (OContract.ProductId == OData.ProductId)
                    {
                        await _Repo.UpdateAsync(OData);

                    }

                }
                else throw new ResultException("Cannot update null product", (int)HttpStatusCode.BadRequest);
            }
                
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
