using System;
using CinemaAppBackend.Extensions;

namespace CinemaApp.Controllers
{
    public static class CinemaHallExitController
    {
        public static void ExitMenu()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thank you for using the cinema hall app. Press any key to exit !!!");
                Console.ReadLine();
                Console.ResetColor();
            }
            catch (Exception e)
            {
                e.HandleException("Error showing current booking status for cinema hall");
            }

        }
    }
}
