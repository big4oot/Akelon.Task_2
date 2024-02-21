using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelon.Task_2.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
    public class WorksheetNameAttribute : Attribute
    {
        public WorksheetNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
