using MediatR;

namespace Akelon.Task_2.Presentation.Interfaces
{
    internal interface IConsoleController
    {
        Task Execute(IMediator mediator);
    }
}
