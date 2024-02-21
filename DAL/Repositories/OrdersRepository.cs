using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Interfaces;
using Akelon.Task_2.Domain.Models;

namespace Akelon.Task_2.DAL.Repositories
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly ExcelContext _excelContext;

        public OrdersRepository(ExcelContext excelContext)
        {
            _excelContext = excelContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _excelContext.Orders;
        }

        public Order? Get(int code)
        {
            return _excelContext.Orders.FirstOrDefault(o => o.Code == code);
        }

        public bool Update(Order item)
        {
            return _excelContext.UpdateValues(item);
        }
    }
}
