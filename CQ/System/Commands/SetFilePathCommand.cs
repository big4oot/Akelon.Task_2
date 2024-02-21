using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelon.Task_2.Utils;
using MediatR;

namespace Akelon.Task_2.CQ.System.Commands
{
    public class SetFilePathCommand : IRequest
    {
        public string FilePath { get; set; }
    }

    public class SetFilePathCommandHandler : IRequestHandler<SetFilePathCommand>
    {
        private readonly Config _config;

        public SetFilePathCommandHandler(Config config)
        {
            _config = config;
        }

        public async Task Handle(SetFilePathCommand request, CancellationToken cancellationToken)
        {
            _config.FilePath = request.FilePath; 
        }
    }
}
