using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CinemaAppBackend;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Utility;
using CinemaAppBackendUnitTest.Helpers;
using Moq;
using NUnit.Framework;

namespace CinemaAppBackendUnitTest.Tests
{
    [TestFixture]
    public class GenerateCinemaHallStatisticsTest
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
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics())
                .Throws<ArgumentNullException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            Assert.Catch<ArgumentNullException>(() => _cinemaAppBackendRepository.GenerateCinemaHallStatistics());
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

            var cinemaSeat =  CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            var cinemaHallStatistics = CinemaHallBackendTestHelper.GetStatistics(cinemaHall);
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics()).Returns(cinemaHallStatistics);

            Assert.AreEqual(cinemaHallStatistics.NumberOfPurchasedTickets,1);
            Assert.AreEqual(cinemaHallStatistics.CurrentIncome,cinemaSeat.TicketPrice);
            Assert.AreEqual(cinemaHallStatistics.PotentialTotalIncome, cinemaHall.Seats.Sum(x => x.TicketPrice));
            Assert.AreEqual(cinemaHallStatistics.PercentageOccupied, ((float)cinemaHallStatistics.NumberOfPurchasedTickets / cinemaHall.TotalCapacity));
        }
        [TestCase("4", "10", "1", "1",10.0f)]
        [TestCase("5", "5", "3", "3",10.0f)]
        public void Test_Case_When_Capacity_Is_Less_Than_50(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber,float expectedPrice)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);

            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);

            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber) - 1, int.Parse(seatNumber) - 1, cinemaHall.NoOfSeatsPerRow);

            var cinemaSeat = CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            var cinemaHallStatistics = CinemaHallBackendTestHelper.GetStatistics(cinemaHall);
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics()).Returns(cinemaHallStatistics);

            Assert.AreEqual(cinemaHallStatistics.NumberOfPurchasedTickets, 1);
            Assert.AreEqual(cinemaSeat.TicketPrice,expectedPrice);
            Assert.AreEqual(cinemaHallStatistics.CurrentIncome, cinemaSeat.TicketPrice);
            Assert.AreEqual(cinemaHallStatistics.PotentialTotalIncome, cinemaHall.Seats.Sum(x => x.TicketPrice));
            Assert.AreEqual(cinemaHallStatistics.PercentageOccupied, ((float)cinemaHallStatistics.NumberOfPurchasedTickets / cinemaHall.TotalCapacity));
        }
        [TestCase("10", "10", "1", "1", 12.0f)]
        [TestCase("5", "12", "3", "3", 12.0f)]
        public void Test_Case_When_Capacity_Is_More_Than_50(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber, float expectedPrice)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);

            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);

            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber) - 1, int.Parse(seatNumber) - 1, cinemaHall.NoOfSeatsPerRow);

            var cinemaSeat = CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            var cinemaHallStatistics = CinemaHallBackendTestHelper.GetStatistics(cinemaHall);
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics()).Returns(cinemaHallStatistics);

            Assert.AreEqual(cinemaHallStatistics.NumberOfPurchasedTickets, 1);
            Assert.AreEqual(cinemaSeat.TicketPrice, expectedPrice);
            Assert.AreEqual(cinemaHallStatistics.CurrentIncome, cinemaSeat.TicketPrice);
            Assert.AreEqual(cinemaHallStatistics.PotentialTotalIncome, cinemaHall.Seats.Sum(x => x.TicketPrice));
            Assert.AreEqual(cinemaHallStatistics.PercentageOccupied, ((float)cinemaHallStatistics.NumberOfPurchasedTickets / cinemaHall.TotalCapacity));
        }
        [TestCase("10", "10", "1", "1", 12.0f)]
        [TestCase("10", "10", "10", "10", 10.0f)]
        public void Test_Case_When_Capacity_Is_More_Than_50_Buying_First_Seat_And_Last_Seat(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber, float expectedPrice)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);

            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);

            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber) - 1, int.Parse(seatNumber) - 1, cinemaHall.NoOfSeatsPerRow);

            var cinemaSeat = CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            var cinemaHallStatistics = CinemaHallBackendTestHelper.GetStatistics(cinemaHall);
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics()).Returns(cinemaHallStatistics);

            Assert.AreEqual(cinemaHallStatistics.NumberOfPurchasedTickets, 1);
            Assert.AreEqual(cinemaSeat.TicketPrice, expectedPrice);
            Assert.AreEqual(cinemaHallStatistics.CurrentIncome, cinemaSeat.TicketPrice);
            Assert.AreEqual(cinemaHallStatistics.PotentialTotalIncome, cinemaHall.Seats.Sum(x => x.TicketPrice));
            Assert.AreEqual(cinemaHallStatistics.PercentageOccupied, ((float)cinemaHallStatistics.NumberOfPurchasedTickets / cinemaHall.TotalCapacity));
        }
        [TestCase("5", "5", "1", "1", 10.0f)]
        [TestCase("5", "5", "5", "5", 10.0f)]
        public void Test_Case_When_Capacity_Is_Less_Than_50_Buying_First_Seat_And_Last_Seat(string noOfRows, string noOfSeatsPerRow, string rowNumber, string seatNumber, float expectedPrice)
        {
            var cinemaHall = CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows, noOfSeatsPerRow);

            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRow)).Returns(cinemaHall);

            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            _cinemaAppBackendRepository.InitializeCinemaHall(rowNumber, seatNumber);

            var seat = CinemaAppBackend.Utility.Utility.ConvertToIndex(int.Parse(rowNumber) - 1, int.Parse(seatNumber) - 1, cinemaHall.NoOfSeatsPerRow);

            var cinemaSeat = CinemaHallBackendTestHelper.BuyTicket(cinemaHall, seat);

            var cinemaHallStatistics = CinemaHallBackendTestHelper.GetStatistics(cinemaHall);
            _mockCinemaAppBackendRepository.Setup(x => x.GenerateCinemaHallStatistics()).Returns(cinemaHallStatistics);

            Assert.AreEqual(cinemaHallStatistics.NumberOfPurchasedTickets, 1);
            Assert.AreEqual(cinemaSeat.TicketPrice, expectedPrice);
            Assert.AreEqual(cinemaHallStatistics.CurrentIncome, cinemaSeat.TicketPrice);
            Assert.AreEqual(cinemaHallStatistics.PotentialTotalIncome, cinemaHall.Seats.Sum(x => x.TicketPrice));
            Assert.AreEqual(cinemaHallStatistics.PercentageOccupied, ((float)cinemaHallStatistics.NumberOfPurchasedTickets / cinemaHall.TotalCapacity));
        }
    }
}
