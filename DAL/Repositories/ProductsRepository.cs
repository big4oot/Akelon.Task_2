using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.DAL.Interfaces;
using Akelon.Task_2.Domain.Models;

namespace Akelon.Task_2.DAL.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly ExcelContext _excelContext;

        public ProductsRepository(ExcelContext excelContext)
        {
            _excelContext = excelContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _excelContext.Products;
        }

        public Product? Get(int code)
        {
            return _excelContext.Products.FirstOrDefault(p => p.Code == code);
        }

        public bool Update(Product item)
        {
            return _excelContext.UpdateValues(item);
        }

    }
}
