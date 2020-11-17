using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using Moq;
using NUnit.Framework;

namespace CinemaAppBackendUnitTest
{
    public abstract class CinemaAppBackendTestBase
    {
        private Mock<ICinemaAppBackendRepository> _mockCinemaAppBackendRepository;
        public ICinemaAppBackendRepository CinemaAppBackendRepository { get; set; }
        [SetUp]
        public void Setup()
        {
            _mockCinemaAppBackendRepository = new Mock<ICinemaAppBackendRepository>();

            CinemaAppBackendRepository = _mockCinemaAppBackendRepository.Object;
        }

        //public void SetupCinemaAppUseCasesForTest(string option)
        //{
        //    switch (option)
        //    {
        //        case "A":
        //        {
        //            ShowCinemaHallInitializationMenu();
        //            break;
        //        }
        //        case "B":
        //        {
        //            ShowCurrentBookingStatus();
        //            break;
        //        }
        //        case "C":
        //        {
        //            ReserveCinemaTicket();
        //            break;
        //        }
        //        case "D":
        //        {
        //            GenerateCinemaHallStatistics();
        //            break;
        //        }
        //        case "E":
        //        {
        //            ExitMenu();
        //            return false;
        //        }
        //    }
        //}

    }
}
