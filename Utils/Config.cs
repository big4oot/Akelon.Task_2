using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelon.Task_2.Utils
{
    public class Config
    {
        public string? FilePath { get; set; }

        public Config(string filePath = null)
        {
            FilePath = filePath;
        }
    }
}
