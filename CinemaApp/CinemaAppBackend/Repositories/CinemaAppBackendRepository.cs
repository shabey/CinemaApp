using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.UseCases;
using Serilog;

namespace CinemaAppBackend.Repositories
{
    public class CinemaAppBackendRepository : ICinemaAppBackendRepository
    {
        private CinemaHall _cinemaHall;
        private readonly IInitializeCinemaHall _initializeCinemaHall;
        private readonly IShowCinemaHallBookingStatus _showCinemaHallBookingStatus;
        public CinemaAppBackendRepository(IInitializeCinemaHall initializeCinemaHall,IShowCinemaHallBookingStatus showCinemaHallBookingStatus)
        {
            _initializeCinemaHall = initializeCinemaHall;
            _showCinemaHallBookingStatus = showCinemaHallBookingStatus;
            _cinemaHall = new CinemaHall();
        }

        public void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow)
        {
            try
            {

                if (_initializeCinemaHall.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRow))
                {
                    _cinemaHall = new CinemaHall(_initializeCinemaHall, int.Parse(noOfRows),
                        int.Parse(noOfSeatsPerRow));
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Initializing Cinema Hall {e.Message}");
                throw;
            }

        }

        public void ShowCurrentBookingStatus()
        {
            try
            {
                _showCinemaHallBookingStatus.ShowCurrentBookingStatus(_cinemaHall);
                Console.WriteLine();
                Console.WriteLine("Press any key to go back !!!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Showing Current Booking Status for Cinema Hall {e.Message}");
                throw;
            }

        }
    }
}
