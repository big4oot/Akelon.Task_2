using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Akelon.Task_2.CQ.Clients.Queries.GetClientsInfoByProductQuery
{
    public class GetClientsInfoByProductQueryValidator : AbstractValidator<GetClientsInfoByProductQuery>
    {
        public GetClientsInfoByProductQueryValidator()
        {
            RuleFor(c => c.ProductName)
                .NotNull().NotEmpty().WithMessage("Наименование товара не должно быть пустым");
        }
    }
}
