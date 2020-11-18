using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Utility
{
    public static class Utility
    {
        /// <summary>
        /// Convert row and col into appropriate index
        /// Converts 2D -> 1D
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="noOfColumns"></param>
        /// <returns></returns>
        public static int ConvertToIndex(int row, int col, int noOfColumns)
        {
            return ((row * noOfColumns) + col);
        }
        /// <summary>
        /// Converts index of an array to corresponding row and col 
        /// Convert from 1D array -> 2D
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

        public static bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}
