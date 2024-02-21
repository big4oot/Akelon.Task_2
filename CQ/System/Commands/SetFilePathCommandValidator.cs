using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Akelon.Task_2.CQ.System.Commands
{
    public class SetFilePathCommandValidator : AbstractValidator<SetFilePathCommand>
    {
        public SetFilePathCommandValidator()
        {
            RuleFor(c => c.FilePath)
                .NotEmpty()
                .Must(HasValidFileExtension)
                .WithMessage("Файл должен иметь расширение .xls или .xlsx");
        }

        private bool HasValidFileExtension(string filePath)
        {
            return !string.IsNullOrWhiteSpace(filePath) &&
                   (filePath.EndsWith(".xlsx") || filePath.EndsWith(".xls"));

        }

    }
}
