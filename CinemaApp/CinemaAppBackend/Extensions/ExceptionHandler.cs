using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Extensions
{
    public static class ExceptionHandler
    {
        public static void HandleError(this Exception ex, string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{errorMessage}{Environment.NewLine}{ex.Message}");
            Console.ResetColor();
            Console.WriteLine("Press any key to go back !!!");
            Console.ReadLine();
            
        }
    }
}
