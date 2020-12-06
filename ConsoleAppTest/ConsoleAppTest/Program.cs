using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Day3Part2(args);
        }


        static void Day1Part1(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            int[] numlines = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                numlines[i] = Convert.ToInt32(lines[i]);
            }
            Array.Sort(numlines);

            for (int i = 0; i < numlines.Length; i++)
            {
                int idx = numlines.Length - 1;
                while (numlines[i] + numlines[idx] > 2020 && idx > i)
                {
                    idx -= 1;
                    if (numlines[i] + numlines[idx] == 2020)
                    {
                        Console.WriteLine($"The answer is {numlines[i]} times {numlines[idx]} which is {numlines[idx] * numlines[i]}!");
                    }
                }
            }
        }

        static void Day1Part2(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            int[] numlines = new int[lines.Length];
            for (int i1 = 0; i1 < lines.Length; i1++)
            {
                numlines[i1] = Convert.ToInt32(lines[i1]);
            }
            Array.Sort(numlines);

            for (int i = 0; i < numlines.Length - 2; i++)
            {
                for (int j = 1; j < numlines.Length - 1; j++)
                {
                    for (int k = 2; k < numlines.Length; k++)
                    {
                        if (numlines[i] + numlines[j] + numlines[k] == 2020)
                        {
                            Console.WriteLine($"The answer is {numlines[i]} times {numlines[j]} times {numlines[k]} which is {numlines[j] * numlines[i] * numlines[k]}!");
                        }
                        else if (numlines[i] + numlines[j] + numlines[k] > 2020)
                        {
                            break;
                        }
                    }
                }
            }
        }

        static void Day2Part1(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            int totalValid = 0;
            int totalLoops = 0;
            foreach (string line in lines)
            {
                string[] splitline = line.Split(' ');
                string[] ltrRange = splitline[0].Split('-');
                double minOcc = Convert.ToInt32(ltrRange[0]);
                double maxOcc = Convert.ToInt32(ltrRange[1]);
                char ch = splitline[1][0];
                int count = splitline[2].ToCharArray().Count(c => c == ch);
                if (count >= minOcc && count <= maxOcc)
                {
                    totalValid += 1;
                }
                totalLoops += 1;
            }

            Console.WriteLine("The total is " + totalValid);
            Console.WriteLine("The total loops are " + totalLoops);
        }

        static void Day2Part2(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            int totalValid = 0;
            int totalLoops = 0;
            foreach (string line in lines)
            {
                string[] splitline = line.Split(' ');
                string[] ltrRange = splitline[0].Split('-');
                int pos1 = Convert.ToInt32(ltrRange[0])-1;
                int pos2 = Convert.ToInt32(ltrRange[1])-1;
                char ch = splitline[1][0];
                string pass = splitline[2];
                if (pass[pos1] == ch ^ pass[pos2] == ch)
                {
                    totalValid += 1;
                }
                totalLoops += 1;
            }

            Console.WriteLine("The total is " + totalValid);
            Console.WriteLine("The total loops are " + totalLoops);
        }

        static void Day3Part1(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            int posX = 0;
            int treeCount = 0;
            int xLen = lines[0].Length;
            for (int posY = 0; posY < lines.Length; posY++)
            {
                char pos = lines[posY][posX];
                if (pos == '#')
                {
                    treeCount += 1;
                }
                posX = (posX + 3) % xLen;
            }

            Console.WriteLine("The total is " + treeCount);

        }

        static void Day3Part2(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            int[,] changeList = new int[5,2] { { 1, 1 },{ 3, 1 },{ 5, 1 },{ 7, 1 },{ 1, 2 } };
            List<int> treeList = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                int xChange = changeList[i, 0];
                int yChange = changeList[i, 1];
                int posX = 0;
                int treeCount = 0;
                int xLen = lines[0].Length;
                for (int posY = 0; posY < lines.Length; posY=posY+yChange)
                {
                    char pos = lines[posY][posX];
                    if (pos == '#')
                    {
                        treeCount += 1;
                    }
                    posX = (posX + xChange) % xLen;
                }
                treeList.Add(treeCount);
            }

            double totalTreeNum = 1;
            foreach (int count in treeList)
            {
                totalTreeNum *= count;
                Console.WriteLine("One total is " + count);
            }
            Console.WriteLine("The total is " + totalTreeNum);

        }
    }
}
