using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utils;
using System.IO;


namespace AdventOfCode.Days
{
    public class Day02 : IAdventExecutable
    {

        public bool IsRunning { get; set; }
        int _twoCount, _threeCount;

        int Checksum
        {
            get
            {
                return _twoCount * _threeCount;
            }
        }

        public void Run(string[] args)
        {

            IsRunning = true;
            var programInput = File.ReadAllLines("Resources/input_day2.txt");

            bool bTwoFound = false, bThreeFound = false;

            SortedDictionary<char, int> charMapping = new SortedDictionary<char, int>();
            for (int i  = 0; i < programInput.Length; ++i)
            {
                charMapping.Clear();
                for (int j = 0; j < programInput[i].Length; ++j)
                {
                    if (!charMapping.ContainsKey(programInput[i][j]))
                    {
                        charMapping.Add(programInput[i][j], 0);
                    }
                    charMapping[programInput[i][j]]++;
                }

                foreach (var kvp in charMapping)
                {
                    if (!bTwoFound && kvp.Value.Equals(2))
                    {
                        _twoCount++;
                        bTwoFound = true;
                        continue;
                    }

                    if (!bThreeFound && kvp.Value.Equals(3))
                    {
                        _threeCount++;
                        
                        bThreeFound = true;
                        continue;
                    }                    
                }

                bTwoFound = bThreeFound = false;
            }

            Console.WriteLine($"Finished Analysing, Checksum determined as {Checksum}");


            IsRunning = false;
        }
    }
}
