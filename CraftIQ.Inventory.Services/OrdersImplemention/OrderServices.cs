using CraftIQ.Inventory.Core.Entites.Orders.spcefication;
using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CraftIQ.Inventory.Services.OrdersImplemention
{
    public class OrderServices<TRequest, TResponse>(IRepository<Order> OrderRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Order> _OrderRepository = OrderRepository;

        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var Ocntract = contract as OrderOpertionContract;
            if (Ocntract == null)
            {
                throw new ResultException("Invalid contract type. Expected Order.",((int)HttpStatusCode.BadRequest));
            }
            var OData = new Order(Guid.Empty, Ocntract.SupplierId, Ocntract.OrderDate, Ocntract.TotalAmount, Ocntract.Status, Ocntract.ExpectedDeliveryDate, Ocntract.OrderType, Ocntract.ReceivedDate);
            var oResult =await _OrderRepository.AddAsync(OData);
            var response = new OrderContract(oResult.OrderId, Guid.Empty, oResult.OrderDate, oResult.TotalAmount, oResult.Status, oResult.ExpectedDeliveryDate, oResult.OrderType, oResult.ReceivedDate);

            return response as dynamic;
        }

        public async ValueTask Delete(Guid ContractId)
        {
            if (ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid ContractId. It cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var spec = new ReadByIdSpcefication(ContractId);
            var oData = await _OrderRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"Order with ID {ContractId} not found.", ((int)HttpStatusCode.NotFound));
            }
            await _OrderRepository.DeleteAsync(oData);
        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var spec = new ReadSpcefication();
            var oData = await _OrderRepository.ListAsync(spec);
            if (oData == null || oData.Count == 0)
            {
                throw new ResultException("No orders found.", ((int)HttpStatusCode.NotFound));
            }
            return oData.Select(x => new OrderContract(x.OrderId, x.SupplierId, x.OrderDate, x.TotalAmount, x.Status, x.ExpectedDeliveryDate, x.OrderType, x.ReceivedDate)).ToList() as List<TResponse>;
        }

        public async ValueTask<TResponse> GetById(Guid ContractId)
        {
            if(ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid ContractId. It cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }   
            var spec = new ReadByIdSpcefication(ContractId);
            var oData = await _OrderRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"Order with ID {ContractId} not found.", ((int)HttpStatusCode.NotFound));
            }
            return new OrderContract(oData.OrderId, oData.SupplierId, oData.OrderDate, oData.TotalAmount, oData.Status, oData.ExpectedDeliveryDate, oData.OrderType, oData.ReceivedDate) as dynamic;
        }

        public async ValueTask<List<TResponse>> GetByParentId(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask Update(TRequest contract, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ResultException("Invalid ID. It cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var spec = new ReadByIdSpcefication(id);
            var oData = await _OrderRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"Order with ID {id} not found.", ((int)HttpStatusCode.NotFound));
            }
            var Ocntract = contract as OrderOpertionContract;
            if (Ocntract == null)
            {
                throw new ResultException("Invalid contract type. Expected Order.", ((int)HttpStatusCode.BadRequest));
            }
            oData.UpdateOrder(Guid.Empty, Ocntract.OrderDate, Ocntract.TotalAmount, Ocntract.Status, Ocntract.ExpectedDeliveryDate, Ocntract.OrderType, Ocntract.ReceivedDate);
            await _OrderRepository.UpdateAsync(oData);

        }

        public async ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
