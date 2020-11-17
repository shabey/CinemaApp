using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Services;
using Moq;
using NUnit.Framework;

namespace CinemaAppBackendUnitTest
{
    public class CinemaHallValidationServiceTest
    {
        //private Mock<ICinemaHallValidationService> _mockCinemaHallValidationService;
        //private ICinemaHallValidationService _cinemaHallValidationService;
        //[SetUp]
        //public void Setup()
        //{
        //    _mockCinemaHallValidationService= new Mock<ICinemaHallValidationService>();
        //    //_mockCinemaHallValidationService.Setup(x => x.ValidateCinemaHallDimensions("", ""))
        //    //    .Throws<ArgumentOutOfRangeException>();
        //    //_mockCinemaHallValidationService.Setup(x => x.ValidateCinemaHallDimensions("0", "0"))
        //    //    .Throws<ArgumentOutOfRangeException>();
        //    //_mockCinemaHallValidationService.Setup(x => x.ValidateCinemaHallDimensions("a", "b"))
        //    //    .Throws<ArgumentOutOfRangeException>();
        //    //_mockCinemaHallValidationService.Setup(x => x.ValidateCinemaHallDimensions("-3", "-3"))
        //    //    .Throws<ArgumentOutOfRangeException>();
        //    //_mockCinemaHallValidationService.Setup(x => x.ValidateCinemaHallDimensions("3", "3"))
        //    //    .Returns(true);
        //    _mockCinemaHallValidationService.Setup(x=>x.ValidateCinemaHallDimensions(It.IsAny<string>(),It.IsAny<string>())).Returns(()=>vali);
        //    var useCaseConfig = new UseCaseConfiguration();
            
        //    _cinemaHallValidationService = useCaseConfig.BuildCinemaHallValidationService();
        //}
        //[TestCase("", "")]
        //[TestCase("0","0")]
        //[TestCase("a", "b")]
        //[TestCase("-3", "-3")]

        //public void Test_InvalidCinemaHallDimensions(string noOfRows, string noOfSeatsPerRows)
        //{
        //    Assert.Catch<ArgumentOutOfRangeException>(() => _cinemaHallValidationService.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRows));
        //}
        //[TestCase("3", "3")]

        //public void Test_ValidCinemaHallDimensions(string noOfRows, string noOfSeatsPerRows)
        //{
        //    Assert.IsTrue(_cinemaHallValidationService.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRows));
        //}
    }
}
