using Akelon.Task_2.CQ.Clients.Queries.GetClientsInfoByProductQuery;
using Akelon.Task_2.Presentation.Interfaces;
using FluentValidation;
using MediatR;

namespace Akelon.Task_2.Presentation.Controllers
{
    public class GetClientsInfoByOrderedProductController : IConsoleController
    {
        public async Task Execute(IMediator mediator)
        {
            Console.WriteLine(MenuMessages.EnterProductName);
            var productName = Console.ReadLine();

            try
            {
                var clientsWhoOrderedTargetProduct = await mediator.Send(new GetClientsInfoByProductQuery()
                {
                    ProductName = productName
                });

                if (clientsWhoOrderedTargetProduct == null || !clientsWhoOrderedTargetProduct.Any())
                {
                    Console.WriteLine(MenuMessages.ClientsWhoOrderedTargetProductNotFound(productName));
                    return;
                }

                Console.WriteLine(MenuMessages.ClientsWhoOrderedTargetProduct(clientsWhoOrderedTargetProduct));
            }
            catch (ValidationException ex)
            {
                foreach (var validationFailure in ex.Errors)
                {
                    Console.WriteLine(validationFailure.ErrorMessage);
                }
            }

        }
    }
}
