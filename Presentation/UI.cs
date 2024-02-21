using Akelon.Task_2.Presentation.Controllers;
using Akelon.Task_2.Presentation.Interfaces;
using MediatR;

namespace Akelon.Task_2.Presentation
{
    public class UI
    {
        private readonly IMediator _mediator;
        private bool _isAppStopped;

        public UI(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Show()
        {
            while (!_isAppStopped)
            {
                var choice = DisplayMenu(MenuMessages.Main);
                
                IConsoleController? controller = GetCommandByChoice(choice);
                if (controller == null)
                {
                    Console.WriteLine("Неизвестная команда");
                    continue;
                }
                await controller.Execute(_mediator);

            }
         
        }

        private IConsoleController? GetCommandByChoice(int choice)
        {
            Console.Clear();

            switch (choice)
            {
                case 1:
                    return new EnterFilePathController();
                case 2:
                    return new GetClientsInfoByOrderedProductController();
                case 3:
                    return new UpdateClientContactFullNameController();
                case 4:
                    return new GetGoldenClientController();
                case 5:
                    _isAppStopped = true;
                    return new ExitController();
                default:
                    return null;
               
            }
        }

        private int DisplayMenu(string menuMessage)
        {
            Console.Write(menuMessage + "\n");
            return (int)char.GetNumericValue((char)Console.ReadKey().Key);
        }
    }

}
