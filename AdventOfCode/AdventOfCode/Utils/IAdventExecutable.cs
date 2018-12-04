using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utils
{
    interface IAdventExecutable
    {

        void Run(string[] args);

        bool IsRunning { get; set; }
    }
}
