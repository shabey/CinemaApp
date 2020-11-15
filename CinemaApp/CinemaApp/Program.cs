using System;

namespace CinemaApp
{
    public class Program
    {
        private static ConsoleKeyInfo _choice;
        static void Main(string[] args)
        {
            
            bool showOptionsMenu;
            do
            {
                showOptionsMenu = ShowOptionsMenu();
            } while (showOptionsMenu);

        }
        private static bool ShowOptionsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Cinemax cinema theater");
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("A)   Initialize cinema theater");
            Console.WriteLine("B)   Show cinema booking status");
            Console.WriteLine("C)   Buy a ticket for a specific seat");
            Console.WriteLine("D)   Cinema statistics");
            Console.WriteLine("E)   Exit");
            Console.Write("\r\nSelect an option: ");
            _choice = Console.ReadKey(false); // show the key as you read it
            switch (_choice.KeyChar.ToString().ToLower())
            {
                case "a":
                    return true;
                case "b":
                    return true;
                case "c":
                    return true;
                case "d":
                    return true;
                case "e":
                    return false;
                default:
                    return true;
            }
        }
    }
}
