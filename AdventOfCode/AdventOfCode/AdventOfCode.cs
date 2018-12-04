using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using AdventOfCode.Utils;
namespace AdventOfCode
{
    class AdventOfCode
    {
        static void Main(string[] args)
        {
            bool bAppRunning = true;
            while (bAppRunning)
            {
                loopStart:
                Console.Write("Which day would you like to run? ");

                var dayNumber = 0;
                do
                {
                    var day = Console.ReadLine();
                    if (day.ToLower().Equals("q"))
                    {
                        bAppRunning = false;
                        goto quit;
                    }

                    if (!int.TryParse(day, out dayNumber))
                    {
                        Console.WriteLine("Please enter a valid day");
                    }
                } while (dayNumber == 0);

               
                var dayTemplate = Type.GetType("AdventOfCode.Days.Day" + ((dayNumber < 10) ? $"0{dayNumber}" : $"{dayNumber}"));                    
                IAdventExecutable currentDay = dayTemplate != null ? (IAdventExecutable)Activator.CreateInstance(dayTemplate) : null;
                currentDay?.Run(args);            

            }
            quit:
            Console.WriteLine("Goodbye");
            Thread.Sleep(1500);
        }
    }
}
