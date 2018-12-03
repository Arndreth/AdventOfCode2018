using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var programInput = File.ReadAllLines("Resources/input.txt");
            List<int> seenFrequencies = new List<int>() {0};
            int finalOutput = 0, firstPassSummation;
            char sign;
            int value;
            bool bFound = false, bFirstLoop = true;

            for (int i = 0; i < programInput.Length; ++i)
            {
                sign = programInput[i][0];
                value = int.Parse(programInput[i].Substring(1));
                finalOutput += (sign.Equals('+') ? value : -value);

                if (seenFrequencies.Contains(finalOutput))
                {
                    Console.WriteLine("\n---");
                    Console.WriteLine($"Duplicate Frequency Found: {finalOutput}");
                    break;
                }

                seenFrequencies.Add(finalOutput);
                Console.Write($"\rFrequencies Scanned: {seenFrequencies.Count}");

                //Reset the loop
                if (i == programInput.Length - 1)
                {
                    //Store part one answer
                    if (bFirstLoop)
                    {
                        firstPassSummation = finalOutput;
                        bFirstLoop = false;
                    }

                    //Reset to -1, then ++i kicks in to make it 0 for next iteration
                    i = -1;
                }
            }

            Console.WriteLine($"Part One Answer: {firstPassSummation}");

            //Wait for user input so that we can actually see the answers before they vanish
            Console.ReadKey();
        }
    }
}
