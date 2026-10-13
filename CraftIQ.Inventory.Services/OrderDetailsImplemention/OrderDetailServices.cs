using CraftIQ.Inventory.Core.Entites.OrderDetails;
using CraftIQ.Inventory.Core.Entites.OrderDetails.spcefication;
using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Core.Entites.Orders.spcefication;
using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Core.Entites.Products.Specification;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;
namespace CraftIQ.Inventory.Services.OrderDetailsImplemention
{
    public class OrderDetailServices<TRequest, TResponse>(IRepository<OrderDetail> OrderDetailRepository,IRepository<Order>OrderRepository,IRepository<Product>ProductRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<OrderDetail> _OrderDetailRepository = OrderDetailRepository;
        private readonly IRepository<Order> _OrderRepository = OrderRepository;
        private readonly IRepository<Product> _PRoductRepository=ProductRepository;

        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var oContract = contract as OrderDetailOpertionContract;
            if (oContract == null)
            {
                throw new ResultException("Invalid contract type. Expected OrderDetail.", ((int)HttpStatusCode.BadRequest));
            }
            var orderDetail = new OrderDetail(Guid.Empty, oContract.Quantity, oContract.TotalPrice);
            var specorder = new Core.Entites.Orders.spcefication.ReadByIdSpcefication(oContract.OrderId);
            var order = await _OrderRepository.FirstOrDefaultAsync(specorder);
            if (order == null)
                throw new ResultException($"the order id {oContract.OrderId} Not Exist ", ((int)HttpStatusCode.BadRequest));
            var specproduct = new ReadByIdSpecification(oContract.ProductId);
            var product = await _PRoductRepository.FirstOrDefaultAsync(specproduct);
            if (product == null)
                throw new ResultException($"the product id {oContract.ProductId} Not Exist ", ((int)HttpStatusCode.BadRequest));
             orderDetail.SetOrder(order);
            orderDetail.SetProduct(product);

            var oResult = await _OrderDetailRepository.AddAsync(orderDetail);
            var response = new OrderDetailContract(oResult.OrderDetailsId, oResult.Quantity,oContract.ProductId,oContract.OrderId, oResult.TotalPrice);

            return response as dynamic;
        }

        public async ValueTask Delete(Guid ContractId)
        {
           if(ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid ContractId. It cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var spec = new Core.Entites.OrderDetails.spcefication.ReadByIdSpcefication(ContractId);
            var oData = await _OrderDetailRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"OrderDetail with ID {ContractId} not found.", ((int)HttpStatusCode.NotFound));
            }
            await _OrderDetailRepository.DeleteAsync(oData);
        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var spec = new Core.Entites.OrderDetails.spcefication.ReadSpcefication();
            var oData = await _OrderDetailRepository.ListAsync(spec);
            if (oData == null || !oData.Any())
            {
                throw new ResultException("No OrderDetails found.", ((int)HttpStatusCode.NotFound));
            }
            var OResult = oData.Select(o => new OrderDetailContract(o.OrderDetailsId, o.Quantity,o.Order.OrderId,o.Product.ProductId, o.TotalPrice)).ToList();
            return OResult as dynamic;
        }

        public async  ValueTask<TResponse> GetById(Guid ContractId)
        {
           if (ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid ContractId. It cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var spec = new Core.Entites.OrderDetails.spcefication.ReadByIdSpcefication(ContractId);
            var oData = await _OrderDetailRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"OrderDetail with ID {ContractId} not found.", ((int)HttpStatusCode.NotFound));
            }
            var OResult = new OrderDetailContract(oData.OrderDetailsId, oData.Quantity,oData.Product.ProductId,oData.Order.OrderId, oData.TotalPrice);
            return OResult as dynamic;
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
            if (contract == null)
            {
                throw new ResultException("Contract cannot be null.", ((int)HttpStatusCode.BadRequest));
            }

            var spec = new Core.Entites.OrderDetails.spcefication.ReadByIdSpcefication(id);
            var oData = await _OrderDetailRepository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException($"OrderDetail with ID {id} not found.", ((int)HttpStatusCode.NotFound));
            }

            var oContract = contract as OrderDetailOpertionContract;
            if (oContract == null)
            {
                throw new ResultException("Invalid contract type. Expected OrderDetail.", ((int)HttpStatusCode.BadRequest));
            }

            // 2. التحقق من وجود الـ Order في قاعدة البيانات
            var specOrder = new Core.Entites.Orders.spcefication.ReadByIdSpcefication(oContract.OrderId);
            var order = await _OrderRepository.FirstOrDefaultAsync(specOrder);
            if (order == null)
            {
                throw new ResultException($"Order with ID {oContract.OrderId} does not exist.", ((int)HttpStatusCode.BadRequest));
            }

            // 3. التحقق من وجود الـ Product في قاعدة البيانات
            var specProduct = new ReadByIdSpecification(oContract.ProductId);
            var product = await _PRoductRepository.FirstOrDefaultAsync(specProduct);
            if (product == null)
            {
                throw new ResultException($"Product with ID {oContract.ProductId} does not exist.", ((int)HttpStatusCode.BadRequest));
            }
            oData.Quantity = oContract.Quantity;
            oData.TotalPrice = oContract.TotalPrice;

            oData.SetOrder(order);
            oData.SetProduct(product);
         

            await _OrderDetailRepository.UpdateAsync(oData);

        }

        public async ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
