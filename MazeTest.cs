using System;
using Xunit;

namespace OutOfTheMaze
{
    public class Maze_Test
    {

        //Create a default Maze with GridSize is 3;
        private Maze CreateDefaultMazeWithSizeEqualTo3()
        {
            return new Maze(3);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void BlockCell_TwoOrThree_ReturnSuccessful(int cellNumber)
        {
            var mockMaze = CreateDefaultMazeWithSizeEqualTo3();
            var isSuccessful = mockMaze.BlockCell(cellNumber);
            Assert.True(isSuccessful);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(9)]
        public void BlockCell_OneOrNine_ReturnFalse(int cellNumber)
        {
            var mockMaze = CreateDefaultMazeWithSizeEqualTo3();
            var isSuccessful = mockMaze.BlockCell(cellNumber);
            Assert.False(isSuccessful);
        }


        [Fact]
        public void RunDefaultMaze_BlockedCellTwoAndFour_ReturnNoPathAvaliable()
        {
            var mockMaze = CreateDefaultMazeWithSizeEqualTo3();
            mockMaze.BlockCell(2);
            mockMaze.BlockCell(4);
            mockMaze.Run();
            var path = mockMaze.GetPath();
            Assert.Equal("No path avaliable!", path);
        }

        [Fact]
        public void RunDefaultMaze_BlockedCellThreeAndFive_ReturnCorrectPath()
        {
            var mockMaze = CreateDefaultMazeWithSizeEqualTo3();
            mockMaze.BlockCell(3);
            mockMaze.BlockCell(5);
            mockMaze.Run();
            var path = mockMaze.GetPath();
            Assert.Equal("Find a path : 1 -> 4 -> 7 -> 8 -> 9", path);
        }


        

    }
}