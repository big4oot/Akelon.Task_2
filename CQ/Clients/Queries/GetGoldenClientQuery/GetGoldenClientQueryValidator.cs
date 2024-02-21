using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Akelon.Task_2.CQ.Clients.Queries.GetGoldenClientQuery
{
    public class GetGoldenClientQueryValidator : AbstractValidator<GetGoldenClientQuery>
    {
        public GetGoldenClientQueryValidator()
        {
            RuleFor(q => q.Month)
                .Must(m => m == 0 || (m >= 1 && m <= 12))
                .WithMessage("Месяц должен быть целым числом от 1 до 12");


            RuleFor(q => q.Year)
                .Must(y => y == 0 || (y >= DateTime.MinValue.Year && y <= DateTime.MaxValue.Year))
                .WithMessage($"Год должен был целым числом от {DateTime.MinValue.Year} до {DateTime.MaxValue.Year}");

            RuleFor(q => new { q.Month, q.Year })
                .Must(pair => pair.Month != 0 || pair.Year != 0)
                .WithMessage("Необходимо указать месяц или год");
        }
    }
}
