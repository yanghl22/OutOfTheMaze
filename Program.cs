using System;
using System.Linq;

namespace OutOfTheMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    int gridSize = GetGridSize();
                    int blockedSize = GetBlockedSize(gridSize);
                    Maze maze = new Maze(gridSize);
                    if (GetBlockCellArray(maze, blockedSize, gridSize))
                    {
                        Console.WriteLine(maze.Run());
                    }

                    Console.WriteLine("Press 'Enter' to continue, 'ctrl + c' to exit!!!");
                    string exit = Console.ReadLine();
                    if (exit.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static int GetGridSize()
        {
            Console.WriteLine("Please enter the size of the grid, it should be a number between 2 to 8;");
            string input = Console.ReadLine();
            int size;
            Int32.TryParse(input, out size);
            if (size >= 2 && size <= 8)
            {
                return size;
            }
            return GetGridSize();
        }

        private static int GetBlockedSize(int gridSize)
        {
            Console.WriteLine(string.Format("Please enter the number of blocked cells, it should between 1 to {0};", gridSize - 1));
            string input = Console.ReadLine();
            int blockedSize;
            Int32.TryParse(input, out blockedSize);
            if (blockedSize >= 1 && blockedSize < gridSize)
            {
                return blockedSize;
            }
            return GetBlockedSize(gridSize);
        }
        
        private static bool GetBlockCellArray(Maze maze, int blockedSize, int gridSize)
        {
            Console.WriteLine(string.Format("Please enter {0} blocked cells, the blocked cells should be nonduplicated numbers between 2 to {1} seperated by comma; e.g. '3,4,5' ", blockedSize, gridSize * gridSize - 1));
            string input = Console.ReadLine();
            string[] strArr = input.Split(",");
            int[] intArr = Array.ConvertAll(strArr, s => int.Parse(s.Trim()));
            intArr = intArr.Distinct().ToArray();
            if (blockedSize != intArr.Length)
            {
                return GetBlockCellArray(maze, blockedSize, gridSize);
            }
            foreach (int number in intArr)
            {
                if (!maze.BlockCell(number))
                {
                    return GetBlockCellArray(maze, blockedSize, gridSize);
                }
            }
            return true;
        }
    }

}