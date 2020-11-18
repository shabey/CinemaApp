using CinemaAppBackend;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Models;

namespace CinemaAppBackendUnitTest.Helpers
{
    public static class CinemaHallBackendTestHelper
    {
        public static CinemaHall GetCinemaHallForTest(string noOfRows,string noOfSeatsPerRows)
        {
            var cinemaHall = new CinemaHall(int.Parse(noOfRows), int.Parse(noOfSeatsPerRows));
            for (var row = 0; row < cinemaHall.NoOfRows; row++)
            {
                for (var col = 0; col < cinemaHall.NoOfSeatsPerRow; col++)
                {
                    cinemaHall.Seats.Add(new CinemaSeat(row, col, cinemaHall.NoOfSeatsPerRow, cinemaHall.TotalCapacity));
                }
            }

            return cinemaHall;
        }

        public static CinemaSeat BuyTicket(CinemaHall cinemaHall, int seatNumber)
        {
            var cinemaSeat = cinemaHall.Seats.Find(x => x.SeatNumber == seatNumber);
            cinemaSeat.BookingStatus = Constants.BookingStatus.Reserved;
            cinemaSeat.TicketPrice = cinemaSeat.GetTicketPrice(cinemaHall.TotalCapacity);
            return cinemaSeat;
        }

        public static CinemaHallStatistics GetStatistics(CinemaHall cinemaHall)
        {
            return new CinemaHallStatistics()
            {
                NumberOfPurchasedTickets = cinemaHall.GetNumberOfPurchasedTickets(),
                TotalNumbersOfSeats = cinemaHall.TotalCapacity,
                PercentageOccupied = cinemaHall.GetPercentageOccupied(),
                CurrentIncome = cinemaHall.GetCurrentIncome(),
                PotentialTotalIncome = cinemaHall.GetPotentialTotalIncome()
            };
        }

    }
}
