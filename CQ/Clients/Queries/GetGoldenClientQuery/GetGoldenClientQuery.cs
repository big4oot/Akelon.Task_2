using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Repositories;
using Akelon.Task_2.Utils.DTOs;
using AutoMapper;
using MediatR;

namespace Akelon.Task_2.CQ.Clients.Queries.GetGoldenClientQuery
{
    public class GetGoldenClientQuery : IRequest<GoldenClientDto>
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
    }

    public class GetGoldenClientQueryHandler : IRequestHandler<GetGoldenClientQuery, GoldenClientDto>
    {
        private readonly ClientsRepository _clientsRepository;
        private readonly OrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetGoldenClientQueryHandler(ClientsRepository clientsRepository, OrdersRepository ordersRepository, IMapper mapper)
        {
            _clientsRepository = clientsRepository;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<GoldenClientDto> Handle(GetGoldenClientQuery request, CancellationToken cancellationToken)
        {
            var filteredOrders = _ordersRepository.GetAll();
            if (filteredOrders == null) return null!;

            if (request.Month != 0)
            {
                filteredOrders = filteredOrders.Where(o => o.PublishDate.Month == request.Month);
            }
            else if (request.Year != 0)
            {
                filteredOrders = filteredOrders.Where(o => o.PublishDate.Year == request.Year);
            }


            var goldenClient = _clientsRepository.GetAll()
                .Join(filteredOrders, clients => clients.Code, order => order.ClientCode,
                    (client, order) => new { Client = client, Order = order })
                .GroupBy(_ => _.Client)
                .OrderByDescending(_ => _.Count())
                .Select(_ => _.Key)
                .FirstOrDefault();

            return _mapper.Map<GoldenClientDto>(goldenClient);
        }
    }
}
