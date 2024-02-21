using Akelon.Task_2.CQ.System.Commands;
using Akelon.Task_2.Presentation.Interfaces;
using FluentValidation;
using MediatR;

namespace Akelon.Task_2.Presentation.Controllers
{
    public class EnterFilePathController : IConsoleController
    {
        public async Task Execute(IMediator mediator)
        {
            Console.WriteLine(MenuMessages.EnterFilePath);
            string? filePath = Console.ReadLine(); // TODO: Validate

            try
            {
                await mediator.Send(new SetFilePathCommand
                {
                    FilePath = filePath
                });
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
