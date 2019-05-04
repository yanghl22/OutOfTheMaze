using System;
using System.Collections.Generic;
using System.Text;

namespace OutOfTheMaze
{
    public class Maze
    {
        int size;
        Stack<int> stepStack;
        int[] grid;
        int gridLength;
        public Maze(int gridSize)
        {
            Init(gridSize);
        }

        private void Init(int gridSize)
        {
            size = gridSize;
            grid = new int[size * size];
            gridLength = size * size;
            for (int i = 0; i < gridLength; i++)
            {
                grid[i] = i + 1;
            }
            stepStack = new Stack<int>();
            stepStack.Push(1);
        }

        public void Run()
        {
            int top = stepStack.Peek();
            while (top < gridLength)
            {
                if (CanGoRight())
                {
                    GoRight();
                }
                else if (CanGoDown())
                {
                    GoDown();
                }
                else
                {
                    GoBack();
                }

                if (stepStack.Count == 0 || stepStack.Peek() == gridLength)
                {
                    break;
                }
            }

            PrintPath();
        }

        public bool Block(int number)
        {
            if (Validate(number))
            {
                grid[number - 1] = 0;
                return true;
            }
            return false;
        }

        private bool CanGoRight()
        {
            int top = stepStack.Peek();

            if ((top % size) != 0 && grid[top] > 0)
            {
                return true;
            }
            return false;
        }

        private void GoRight()
        {
            int top = stepStack.Peek();
            stepStack.Push(top + 1);
        }

        private bool CanGoDown()
        {
            int top = stepStack.Peek();

            if ((top / size < size - 1 || (top / size == size - 1 && top % size == 0)) && grid[top + size - 1] > 0)
            {
                return true;
            }
            return false;
        }

        private void GoDown()
        {
            int top = stepStack.Peek();
            stepStack.Push(top + size);
        }

        private void GoBack()
        {
            int top = stepStack.Peek();
            grid[top - 1] = 0;
            stepStack.Pop();
        }

        private bool Validate(int number)
        {
            if (number <= 1 || number >= gridLength || grid[number - 1] == 0)
            {
                return false;
            }
            return true;
        }

        private void PrintPath()
        {
            if (stepStack.Count <= 0)
            {
                Console.WriteLine("No path avaliable!");
            }
            else
            {
                var steps = stepStack.ToArray();
                Array.Reverse(steps);
                StringBuilder path = new StringBuilder();
                Console.WriteLine("Find below path:");
                Console.WriteLine(path.AppendJoin(" -> ", steps).ToString());
            }
        }

    }
}