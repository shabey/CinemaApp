using System;
using System.Linq;
using CinemaAppBackend;
using CinemaAppBackend.Interfaces;
using CinemaAppBackendUnitTest.Helpers;
using Moq;
using NUnit.Framework;

namespace CinemaAppBackendUnitTest.Tests
{
    [TestFixture]
    public class InitializeCinemaHallTests
    {
        private Mock<ICinemaAppBackendRepository> _mockCinemaAppBackendRepository;
        private ICinemaAppBackendRepository _cinemaAppBackendRepository;
        [SetUp]
        public void Setup()
        {
            _mockCinemaAppBackendRepository = new Mock<ICinemaAppBackendRepository>();
        }
        [TestCase("", "")]
        [TestCase("0", "0")]
        [TestCase("a", "b")]
        [TestCase("-3", "-3")]

        public void Test_InvalidInitialization(string noOfRows, string noOfSeatsPerRows)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRows))
                .Throws<ArgumentOutOfRangeException>();
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
            Assert.Catch<ArgumentOutOfRangeException>(() => _cinemaAppBackendRepository.InitializeCinemaHall(noOfRows, noOfSeatsPerRows));
        }
        [TestCase("3", "3")]
        [TestCase("10", "10")]
        public void Test_ValidInitialization(string noOfRows, string noOfSeatsPerRows)
        {
            _mockCinemaAppBackendRepository.Setup(x => x.InitializeCinemaHall(noOfRows, noOfSeatsPerRows)).Returns(CinemaHallBackendTestHelper.GetCinemaHallForTest(noOfRows,noOfSeatsPerRows));
            _cinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;

            var cinemaHall = _cinemaAppBackendRepository.InitializeCinemaHall(noOfRows, noOfSeatsPerRows);
            Assert.IsNotNull(cinemaHall);
            Assert.AreEqual(noOfRows,cinemaHall.NoOfRows.ToString());
            Assert.AreEqual(noOfSeatsPerRows,cinemaHall.NoOfSeatsPerRow.ToString());
            Assert.AreEqual(cinemaHall.TotalCapacity,cinemaHall.Seats.Count);
            //Cinema hall seat collection is initialized and all seats are available for booking
            Assert.IsNotNull(cinemaHall.Seats);
            Assert.IsTrue(cinemaHall.Seats.All(x => x.BookingStatus == Constants.BookingStatus.Available));
            

        }
    }
}
