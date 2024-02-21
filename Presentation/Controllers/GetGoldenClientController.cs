using Akelon.Task_2.CQ.Clients.Queries.GetGoldenClientQuery;
using Akelon.Task_2.Presentation.Interfaces;
using FluentValidation;
using MediatR;

namespace Akelon.Task_2.Presentation.Controllers
{
    public class GetGoldenClientController : IConsoleController
    {
        public async Task Execute(IMediator mediator)
        {
            Console.WriteLine(MenuMessages.EnterMonth);
            int.TryParse(Console.ReadLine(), out var month);

            Console.WriteLine(MenuMessages.EnterYear);
            int.TryParse(Console.ReadLine(), out var year);


            try
            {
                var goldenClient = await mediator.Send(new GetGoldenClientQuery
                    {
                        Month = month,
                        Year = year
                    }
                );

                Console.WriteLine(MenuMessages.GoldenClient(goldenClient));
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }




        }
    }
}
