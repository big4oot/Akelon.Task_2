using Akelon.Task_2.Presentation.Interfaces;
using FluentValidation;
using MediatR;

namespace Akelon.Task_2.Presentation.Controllers
{
    public class UpdateClientContactFullNameController : IConsoleController
    {
        public async Task Execute(IMediator mediator)
        {
            Console.WriteLine(MenuMessages.EnterCompanyName);
            var companyName = Console.ReadLine();

            Console.WriteLine(MenuMessages.EnterClientContactFullName);
            var contactFullName = Console.ReadLine();

            try
            {
                var resultOk = await mediator.Send(new CQ.Clients.Commands.UpdateClientContactFullNameCommand
                {
                    CompanyName = companyName,
                    FullName = contactFullName
                });

                if (resultOk)
                {
                    Console.WriteLine("Данные клиента обновленны");
                }
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
