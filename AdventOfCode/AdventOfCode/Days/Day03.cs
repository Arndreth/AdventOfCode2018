using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utils;

namespace AdventOfCode.Days
{
    class Day03 : IAdventExecutable
    {
        struct FabricArea
        {

            public int ID;
            public int X, Y;
            public int Width, Height;

            public int TotalArea => Width * Height;

            public void Parse(string input)
            {
                string[] chunks = input.Split('@');

                ID = int.Parse(chunks[0].Trim().Substring(1));
                string[] locRaw = chunks[1].Trim().Split(':');
                string[] ints = locRaw[0].Split(',');
                X = int.Parse(ints[0]);
                Y = int.Parse(ints[1]);

                ints = locRaw[1].Trim().Split('x');
                Width = int.Parse(ints[0]);
                Height = int.Parse(ints[1]);

            }
        }

        public void Run(string[] args)
        {
            IsRunning = true;

            var programInput = File.ReadAllLines("Resources/input_day3.txt");

            var fabric = new int[1000, 1000];
            List<FabricArea> sections = new List<FabricArea>(programInput.Length);
            for (int i = 0; i < programInput.Length; ++i)
            {
                FabricArea section = new FabricArea();

                section.Parse(programInput[i]);

                for (int x = 0; x < section.Width; ++x)
                {
                    for (int y = 0; y < section.Height; ++y)
                    {
                        fabric[section.X + x,section.Y + y]++;
                    }
                }

                sections.Add(section);
            }
            //iterate patterns again to find which didn't overlap.
            bool bFound = false;
            FabricArea foundSection = new FabricArea();
            int tally = 0;
            for (int i = 0; i < sections.Count; ++i)
            {
                var section = sections[i];
                tally = 0;
                for (int x = 0; x < section.Width; ++x)
                {
                    for (int y = 0; y < section.Height; ++y)
                    {
                        tally += fabric[section.X + x, section.Y + y] == 1 ? 1 : 0;
                    }
                }

                if (tally == section.TotalArea)
                {
                    foundSection = section;
                    break;
                }
            }

            Console.WriteLine($"Found section of pure intent with ID: {foundSection.ID}");

            //Total
                    int overlapping = 0;
            for (int i = 0; i < 1000; ++i)
            {
                for (int j = 0; j < 1000; ++j)
                {
                    overlapping += (fabric[i, j] >= 2 ? 1 : 0);
                }
            }

            Console.WriteLine($"Total Overlapping Square Inches: {overlapping}");
            IsRunning = false;
        }

        public bool IsRunning { get; set; }
    }
}
