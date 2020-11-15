using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Utility
{
    public static class Utility
    {
        /// <summary>
        /// Converts 2D row and col into 1D -> index
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="noOfColumns"></param>
        /// <returns></returns>
        public static int ConvertToIndex(int row, int col, int noOfColumns)
        {
            var index = ((row * noOfColumns) + col);
            return (index % noOfColumns) + 1;
        }
        /// <summary>
        /// Converts index of an array to corresponding row and col
        /// </summary>
        /// <param name="index"></param>
        /// <param name="noOfColumns"></param>
        /// <returns></returns>
        public static Tuple<int, int> ConvertFromIndex(int index, int noOfColumns)
        {
            var row = index / noOfColumns;
            var col = index % noOfColumns;
            return new Tuple<int, int>(row, col);
        }
    }
}
