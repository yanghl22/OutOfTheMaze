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

        /*
        Create Data structure to initialize Maze object
        Array to store the numbers of Grid.
        Stack to store temp steps.
         */
        private void Init(int gridSize)
        {
            size = gridSize;
            gridLength = size * size;
            grid = new int[gridLength];
            for (int i = 0; i < gridLength; i++)
            {
                grid[i] = i + 1;
            }

            stepStack = new Stack<int>();

            //Run from step 1
            stepStack.Push(1);
        }

        //Run this method to get out the Maze
        public string Run()
        {
            //Run start with step "1";
            int top = stepStack.Peek();

            //Keep running as long as current step is less than the last step
            while (top < gridLength)
            {
                if (CanGoRight())
                {
                    //Move to right if right is accessible
                    GoRight();
                }
                else if (CanGoDown())
                {
                    //Move down if below is accessible
                    GoDown();
                }
                else
                {
                    //Move back if both right and down not accessible
                    GoBack();
                }

                //Jump out the loop if no path available
                if (stepStack.Count == 0)
                {
                    break;
                }

                top = stepStack.Peek();
            }
            return GetPath();
        }

        // Block the specified cell in the Grid 
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
        
        private string GetPath()
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


    }
}