using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Akelon.Task_2.CQ.Clients.Commands
{
    public class UpdateClientContactFullnameCommandValidator : AbstractValidator<UpdateClientContactFullNameCommand>
    {
        public UpdateClientContactFullnameCommandValidator()
        {
            RuleFor(c => c.CompanyName)
                .NotNull().NotEmpty().WithMessage("Наименование компании не может быть пустым");

            RuleFor(c => c.FullName)
                .NotNull().NotEmpty().WithMessage("ФИО контактного лица не может быть пустым");
        }
    }
}
