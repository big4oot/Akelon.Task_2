using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Repositories;
using Akelon.Task_2.Utils.DTOs;
using MediatR;

namespace Akelon.Task_2.CQ.Clients.Queries.GetClientsInfoByProductQuery
{
    public class GetClientsInfoByProductQuery : IRequest<IEnumerable<ClientByOrderedProductDto>>
    {
        public string ProductName { get; set; }
    }

    public class GetClientsInfoByProductQueryHandler : IRequestHandler<GetClientsInfoByProductQuery, IEnumerable<ClientByOrderedProductDto>>
    {
        private readonly ClientsRepository _clientRepository;
        private readonly OrdersRepository _ordersRepository;
        private readonly ProductsRepository _productsRepository;

        public GetClientsInfoByProductQueryHandler(ClientsRepository clientRepository, OrdersRepository ordersRepository, ProductsRepository productsRepository)
        {
            _clientRepository = clientRepository;
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ClientByOrderedProductDto>> Handle(GetClientsInfoByProductQuery request, CancellationToken cancellationToken)
        {

            var products = _productsRepository.GetAll();
            var clients = _clientRepository.GetAll();
            var orders = _ordersRepository.GetAll();

            if (products == null || clients == null || orders == null)
            {
                return null;
            }

            var result = from order in orders
                         join client in clients on order.ClientCode equals client.Code
                         join product in products on order.ProductCode equals product.Code
                         where product.Name == request.ProductName
                         select new ClientByOrderedProductDto() 
                         {
                             Code = client.Code,
                             Company = client.Company,
                             Address = client.Address,
                             FullName = client.FullName,
                             ProductQuantity = order.Quantity,
                             Price = order.Quantity * product.Cost,
                             OrderDate = order.PublishDate,
                         };

            return result;
        }

    }
}
