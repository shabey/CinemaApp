using System;

namespace CinemaApp.Extensions
{
    public static class ErrorHandler
    {
        public static void HandleError(this Exception ex, string errorMessage)
        {
            Console.WriteLine($"{errorMessage}{Environment.NewLine}{ex.Message}");
            Console.WriteLine("Press any key to go back !!!");
            Console.ReadLine();
        }
    }
}
