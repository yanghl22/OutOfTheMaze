using System;
using System.Collections.Generic;

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
            stepStack.Push(0);
        }

        public void Run()
        {
            int cur_step = stepStack.Peek();
            while (cur_step < gridLength - 1)
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
                cur_step = stepStack.Peek();
                if (cur_step == gridLength - 1 || cur_step == 0)
                {
                    break;
                }
            }
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
            int cur_step = stepStack.Peek();

            if ((cur_step % size) < size - 1 && grid[cur_step + 1] > 0)
            {
                return true;
            }
            return false;
        }

        private void GoRight()
        {
            int cur_step = stepStack.Peek();
            stepStack.Push(cur_step + 1);
        }

        private bool CanGoDown()
        {
            int cur_step = stepStack.Peek();

            if ((cur_step / size) < size - 1 && grid[cur_step + size] > 0)
            {
                return true;
            }
            return false;
        }

        private void GoDown()
        {
            int cur_step = stepStack.Peek();
            stepStack.Push(cur_step + size);
        }

        private void GoBack()
        {
            int cur_step = stepStack.Peek();
            grid[cur_step] = 0;
            stepStack.Pop();
        }

        private bool Validate(int number)
        {
            if (number < 1 || number > gridLength - 1 || grid[number] == 0)
            {
                return false;
            }
            return true;
        }

    }
}