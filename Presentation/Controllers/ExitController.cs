using Akelon.Task_2.Presentation.Interfaces;
using MediatR;

namespace Akelon.Task_2.Presentation.Controllers
{
    public class ExitController : IConsoleController
    {
        public Task Execute(IMediator mediator)
        {
            Console.WriteLine(MenuMessages.Goodbye);
            return Task.CompletedTask;
        }
    }
}
