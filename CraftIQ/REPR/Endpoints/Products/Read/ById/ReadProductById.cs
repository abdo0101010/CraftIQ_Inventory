using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Read.ById
{
    public class ReadProductById(InventoryFactory<dynamic,ProductContract> Factory) : EndpointsAsync.WithRequest<ReadProductByIdRequest>.WithActionResult<ReadProductResponse>
    {
        private readonly InventoryFactory<dynamic, ProductContract> _Factory = Factory;
        [HttpGet(Routes.Routes.ProductRoutes.ReadProductById)]
        public override async Task<ActionResult<ReadProductResponse>> HandleAsync( ReadProductByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (request != null)
            {
                var Service = _Factory.Build(nameof(Product));

                var oData = await Service.GetById(request.ProductID);
                var OReesult = new ProductContract(oData.ProductId, oData.InventoryId, oData.Name, oData.Description, oData.UnitPrice, oData.Weight, oData.Length, oData.Width, oData.Height, oData.CategoryId, oData.TaxCost, oData.ProfitPerUnit, oData.ProductionCost);
                return new ReadProductResponse(OReesult);
            }
            else throw new ResultException("you cannot send empty id", ((int)HttpStatusCode.BadRequest));
        }                                                                                                                                                          
    }                                                                                                                                               
}                                                                                                                                      
                                                                                                                         
                                                                                                            
                                                                                         
                                                                       
                                                           
                                               