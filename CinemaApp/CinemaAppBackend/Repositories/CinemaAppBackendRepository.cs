using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.Services;
using CinemaAppBackend.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CinemaAppBackend.Repositories
{
    public class CinemaAppBackendRepository : ICinemaAppBackendRepository
    {
        
        private CinemaHall _cinemaHall;
        private readonly IInitializeCinemaHall _initializeCinemaHall;
        private readonly IShowCinemaHallCurrentStatus _showCinemaHallCurrentStatus;
        private readonly IBuyCinemaTicket _buyCinemaTicket;
        private readonly ICinemaHallValidationService _cinemaHallValidationService;
        private readonly IGenerateCinemaHallStatistics _generateCinemaHallStatistics;

        public CinemaAppBackendRepository(IServiceProvider serviceProvider)
        {
            this._initializeCinemaHall = serviceProvider.GetService<IInitializeCinemaHall>();
            this._showCinemaHallCurrentStatus = serviceProvider.GetService<IShowCinemaHallCurrentStatus>();
            this._buyCinemaTicket = serviceProvider.GetService<IBuyCinemaTicket>();
            this._cinemaHallValidationService = serviceProvider.GetService<ICinemaHallValidationService>();
            this._generateCinemaHallStatistics = serviceProvider.GetService<IGenerateCinemaHallStatistics>();
            this._cinemaHall = new CinemaHall();
        }

        public void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow)
        {
            try
            {

                if (_cinemaHallValidationService.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRow))
                {
                    this._cinemaHall = new CinemaHall(int.Parse(noOfRows),int.Parse(noOfSeatsPerRow));

                    this._initializeCinemaHall.InitializeCinemaHallSeats(this._cinemaHall);
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Initializing Cinema Hall {e.Message}");
                throw;
            }

        }

        public void ShowCinemaHallCurrentStatus()
        {
            try
            {
                if (_cinemaHallValidationService.ValidateCinemaHall(this._cinemaHall))
                {
                    _showCinemaHallCurrentStatus.ShowCurrentBookingStatus(this._cinemaHall);
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Showing Current Status for Cinema Hall {e.Message}");
                throw;
            }

        }
        public void BuyCinemaTicket(string rowNumber, string seatNumber)
        {
            try
            {
                if (_cinemaHallValidationService.ValidateSeatReservation(rowNumber,seatNumber,this._cinemaHall))
                {
                    var seat =
                        Utility.Utility.ConvertToIndex(int.Parse(rowNumber)-1, int.Parse(seatNumber)-1, this._cinemaHall.NoOfSeatsPerRow);

                    if (!_buyCinemaTicket.IsSeatAvailableForReservation(this._cinemaHall, seat))
                    {
                        throw new Exception($"Seat reservation failed!!! seat: {seatNumber}  in row: {rowNumber} is already reserved.");
                    }
                    _buyCinemaTicket.BuyTicket(this._cinemaHall, seat);
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Buying Cinema Ticket {e.Message}");
                throw;
            }

        }

        public void GenerateCinemaHallStatistics()
        {
            try
            {
                if (this._cinemaHall == null)
                {
                    throw new ArgumentNullException($"Cinema hall",
                        "Cinema hall cannot be null. Kindly initialize cinema hall by selecting option A");
                }
                var cinemaHallStatistics = _generateCinemaHallStatistics.GetCinemaHallStatistics(this._cinemaHall);
                if (cinemaHallStatistics!=null)
                {
                    Console.WriteLine(cinemaHallStatistics.ToString());
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Generating Statistics for Cinema Hall {e.Message}");
                throw;
            }
        }
    }
}
