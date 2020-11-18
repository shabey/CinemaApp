using System;
using CinemaAppBackend;
using CinemaAppBackend.Interfaces;
using CinemaAppBackendUnitTest.Helpers;
using Moq;
using NUnit.Framework;

namespace CinemaAppBackendUnitTest.Tests
{
    [TestFixture]
    public class BuyCinemaHallTicketTests
    {
        private Mock<ICinemaAppBackendRepository> _mockCinemaAppBackendRepository;
        private ICinemaAppBackendRepository _cinemaAppBackendRepository;
        [SetUp]
        public void Setup()
        {
            _mockCinemaAppBackendRepository = new Mock<ICinemaAppBackendRepository>();
        }
        [TestCase("0", "0")]
        
        public void Test_Case_When_Cinema_Hall_Is_Null(string rowNumber, string seatNumber)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Throws<ArgumentNullException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            Assert.Catch<ArgumentNullException>(() => _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber));
        }
        [TestCase("0","3")]

        public void Test_Case_When_Cinema_Hall_Is_Having_Zero_Rows(string rowNumber,string seatNumber)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(rowNumber, seatNumber)).Returns(CinemaHallBackendTestHelper.GetCinemaHallForTest(rowNumber,seatNumber));
            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Throws<ArgumentOutOfRangeException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);
            Assert.Catch<ArgumentOutOfRangeException>(() => _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber));
        }
       [TestCase("3","0")]

        public void Test_Case_When_Cinema_Hall_Is_Having_Zero_Seats_Per_Row(string rowNumber, string seatNumber)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(rowNumber, seatNumber)).Returns(CinemaHallBackendTestHelper.GetCinemaHallForTest(rowNumber, seatNumber));
            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Throws<ArgumentOutOfRangeException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);
            Assert.Catch<ArgumentOutOfRangeException>(() => _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber));
        }
        [TestCase("3", "3","0","3")]
        [TestCase("3", "3", "3", "0")]
        [TestCase("3", "3", "4", "4")]
        [TestCase("3", "3", "-3", "-3")]
        public void Test_Case_When_Invalid_Seat_Reservation_Number_Is_Given(string noOfRows,string noOfSeatsPerRow,string rowNumber, string seatNumber)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow));
            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Throws<ArgumentOutOfRangeException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);
            Assert.Catch<ArgumentOutOfRangeException>(() => _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber));
        }
        [TestCase("3", "3", "1", "1")]
        [TestCase("3", "3", "3", "3")]
        public void Test_Case_Seat_Reservation_Success(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);
            
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            
            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);
            
            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber)-1,int.Parse(seatNumber)-1,cinemaHall.NoOfSeatsPerRow);
            
            Assert.IsTrue(cinemaHall.Seats.Find(x=>x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Available);
            
            CinemaHallBackendTestHelper.BuyTicket(cinemaHall,seat);

            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Returns(cinemaHall);

            _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber);
            
            Assert.IsFalse(cinemaHall.Seats.Find(x => x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Available);
            
            Assert.IsTrue(cinemaHall.Seats.Find(x => x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Reserved);
        }

        [TestCase("3", "3", "1", "1")]
        [TestCase("3", "3", "3", "3")]
        public void Test_Case_Reserve_Already_Reserved_Seat(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);

            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);

            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber) - 1, int.Parse(seatNumber) - 1, cinemaHall.NoOfSeatsPerRow);

            Assert.IsTrue(cinemaHall.Seats.Find(x => x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Available);

            CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Returns(cinemaHall);

            _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber);

            Assert.IsFalse(cinemaHall.Seats.Find(x => x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Available);

            Assert.IsTrue(cinemaHall.Seats.Find(x => x.SeatNumber == seat).BookingStatus == Constants.BookingStatus.Reserved);

            _mockCinemaAppBackendRepository.Setup(x => x.BuyCinemaTicket(rowNumber, seatNumber))
                .Throws<Exception>();

            Assert.Catch<Exception>(() => _cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber));
        }
    }
}

