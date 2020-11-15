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
        private readonly IReserveCinemaTicket _reserveCinemaTicket;
        private readonly ICinemaHallValidationService _cinemaHallValidationService;
        public CinemaAppBackendRepository(IInitializeCinemaHall initializeCinemaHall,IShowCinemaHallBookingStatus showCinemaHallBookingStatus,IReserveCinemaTicket reserveCinemaTicket,ICinemaHallValidationService cinemaHallValidationService)
        {
            _initializeCinemaHall = initializeCinemaHall;
            _showCinemaHallBookingStatus = showCinemaHallBookingStatus;
            _reserveCinemaTicket = reserveCinemaTicket;
            _cinemaHallValidationService = cinemaHallValidationService;
            _cinemaHall = new CinemaHall();
        }

        public void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow)
        {
            try
            {

                if (_cinemaHallValidationService.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRow))
                {
                    this._cinemaHall = new CinemaHall(_initializeCinemaHall, int.Parse(noOfRows),
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
                if (_cinemaHallValidationService.ValidateCinemaHall(this._cinemaHall))
                {
                    _showCinemaHallBookingStatus.ShowCurrentBookingStatus(this._cinemaHall);
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Showing Current Booking Status for Cinema Hall {e.Message}");
                throw;
            }

        }
        public void ReserveCinemaTicket(string rowNumber, string seatNumber)
        {
            try
            {
                if (_cinemaHallValidationService.ValidateSeatReservation(rowNumber,seatNumber,this._cinemaHall))
                {
                    var seat =
                        Utility.Utility.ConvertToIndex(int.Parse(rowNumber)-1, int.Parse(seatNumber)-1, this._cinemaHall.NoOfSeatsPerRow);

                    if (!_reserveCinemaTicket.IsSeatAvailableForReservation(this._cinemaHall, seat))
                    {
                        throw new Exception($"Seat reservation failed!!! seat: {seatNumber}  in row: {rowNumber} is already reserved.");
                    }
                    _reserveCinemaTicket.ReserveTicket(this._cinemaHall, seat);
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error($"{MethodBase.GetCurrentMethod().DeclaringType} - Error Reserving Cinema Ticket {e.Message}");
                throw;
            }

        }
    }
}
