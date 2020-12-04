using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day3Challenge
    {
        private double _TreeEncounterCount { get; set; }
        public double TreeEncounterCount { get => _TreeEncounterCount; }
        private static bool HitTreeCheck(char coordinate)
        {
            bool tempBool = false;
            switch (coordinate)
            {
                case '.':
                    tempBool = false;
                    break;
                case '#':
                    tempBool = true;
                    break;
            }
            return tempBool;
        }

        private void HitDemTrees(string[] input, int moveDown, int moveRight)
        {
            int encounterCount = 0;
            int MoveRight = moveRight;
            int MoveDown = moveDown;
            int x = 0;
            int y = 0;
            bool edgeCheck = true;
            while (edgeCheck)
            {
                if (HitTreeCheck(input[y][x]))
                {
                    encounterCount++;
                }
                x += MoveRight;
                y += MoveDown;
                if(y < input.Length)
                {
                    if (x >= input[y].Length)
                    {
                        x = x - input[y].Length;
                    }
                } else
                {
                    edgeCheck = false;
                }
            }
                    
           if(_TreeEncounterCount == 0)
            {
                _TreeEncounterCount = encounterCount;
            }
            else
            {
                _TreeEncounterCount *= encounterCount;
            }
            
        }

        public Day3Challenge(string[] inputFile)
        {
            HitDemTrees(inputFile,1,1);
            HitDemTrees(inputFile, 1, 3);
            HitDemTrees(inputFile, 1, 5);
            HitDemTrees(inputFile, 1, 7);
            HitDemTrees(inputFile, 2, 1);
        }
    }
}
