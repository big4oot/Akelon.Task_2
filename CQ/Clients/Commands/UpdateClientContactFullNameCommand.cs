using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Repositories;
using Akelon.Task_2.Domain.Models;
using MediatR;

namespace Akelon.Task_2.CQ.Clients.Commands
{
    public class UpdateClientContactFullNameCommand : IRequest<bool>
    {
        public string CompanyName { get; set; }
        public string FullName { get; set; }
    }

    public class UpdateClientContactFullNameCommandHandler : IRequestHandler<UpdateClientContactFullNameCommand, bool>
    {
        private readonly ClientsRepository _clientRepository;

        public UpdateClientContactFullNameCommandHandler(ClientsRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(UpdateClientContactFullNameCommand request, CancellationToken cancellationToken)
        {
            Client clientForUpdate;

            try
            {
                clientForUpdate = _clientRepository.GetAll().FirstOrDefault(c => c.Company == request.CompanyName);
            }
            catch (Exception)
            {
                return false;
            }
            if (clientForUpdate == null)
            {
                Console.WriteLine("Клиент не найден");
                return false;
            }

            clientForUpdate.FullName = request.FullName;

            return _clientRepository.Update(clientForUpdate);
        }
    }
}
