using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Extensions
{
    public static class ExceptionHandler
    {
        public static void HandleError(this Exception ex, string errorMessage)
        {
            Console.WriteLine($"{errorMessage}{Environment.NewLine}{ex.Message}");
            Console.WriteLine("Press any key to go back !!!");
            Console.ReadLine();
        }
    }
}
