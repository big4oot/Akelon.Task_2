using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Interfaces;
using Akelon.Task_2.Domain.Models;

namespace Akelon.Task_2.DAL.Repositories
{
    public class ClientsRepository : IRepository<Client>
    {
        private readonly ExcelContext _excelContext;

        public ClientsRepository(ExcelContext excelContext)
        {
            _excelContext = excelContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _excelContext.Clients;
        }

        public Client? Get(int code)
        {
            return _excelContext.Clients.FirstOrDefault(c => c.Code == code);
        }

        public bool Update(Client item)
        {
            return _excelContext.UpdateValues(item);
        }
    }
}
