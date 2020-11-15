using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;
using CinemaAppBackend.UseCases;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using ILogger = Serilog.ILogger;

namespace CinemaAppBackend
{
    public class UseCaseConfiguration
    {
        private IInitializeCinemaHall _initializeCinemaHall;
        private IShowCinemaHallBookingStatus _showCinemaHallBookingStatus;
        public ICinemaAppBackendRepository BuildCinemaAppBackendRepository()
        {
            return new CinemaAppBackendRepository(this._initializeCinemaHall,this._showCinemaHallBookingStatus);
        }
        public UseCaseConfiguration BuildCinemaHallInitializationService()
        {
            _initializeCinemaHall = new InitializeCinemaHall();
            return this;
        }
        public UseCaseConfiguration BuildShowCinemaHallBookingStatusService()
        {
            _showCinemaHallBookingStatus = new ShowCinemaHallBookingStatus();
            return this;
        }
    }
}
