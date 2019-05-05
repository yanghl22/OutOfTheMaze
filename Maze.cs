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

        public bool Run()
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

            return true;
        }
        public string GetPath()
        {
            if (stepStack.Count <= 0)
            {
                return "No path avaliable!";
            }
            else
            {
                var steps = stepStack.ToArray();
                Array.Reverse(steps);
                StringBuilder path = new StringBuilder();
                path.Append("Find a path : ");
                return path.AppendJoin(" -> ", steps).ToString();
            }
        }


        public bool BlockCell(int number)
        {
            if (ValidateBlockedCellNumber(number))
            {
                grid[number - 1] = 0;
                return true;
            }
            return false;
        }

        private bool ValidateBlockedCellNumber(int number)
        {
            if (number <= 1 || number >= gridLength || grid[number - 1] == 0)
            {
                return false;
            }
            return true;
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

        private void PrintPath()
        {

        }

    }
}