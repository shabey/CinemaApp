using System;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;

namespace CinemaApp.Controllers
{
    public static class CinemaHallStatisticsController
    {
        public static void GenerateCinemaHallStatistics(ICinemaAppBackendRepository cinemaAppBackendRepository)
        {
            try
            {
                Console.Clear();
                cinemaAppBackendRepository.ShowCinemaHallCurrentStatus();
                Console.WriteLine();
                cinemaAppBackendRepository.GenerateCinemaHallStatistics();
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to main menu !!!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                e.HandleException("Error showing current booking status for cinema hall");
            }

        }
    }
}
