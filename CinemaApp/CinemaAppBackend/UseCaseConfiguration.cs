using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;
using CinemaAppBackend.Services;
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
        private IShowCinemaHallCurrentStatus _showCinemaHallCurrentStatus;
        private IBuyCinemaTicket _buyCinemaTicket;
        private ICinemaHallValidationService _cinemaHallValidationService;
        private IGenerateCinemaHallStatistics _generateCinemaHallStatistics;
        public ICinemaAppBackendRepository BuildCinemaAppBackendRepository()
        {
            return new CinemaAppBackendRepository(this._initializeCinemaHall,this._showCinemaHallCurrentStatus,this._buyCinemaTicket,this._generateCinemaHallStatistics, this._cinemaHallValidationService);
        }
        public UseCaseConfiguration BuildCinemaHallInitializationService()
        {
            _initializeCinemaHall = new InitializeCinemaHall();
            return this;
        }
        public UseCaseConfiguration BuildShowCinemaHallBookingStatusService()
        {
            _showCinemaHallCurrentStatus = new ShowCinemaHallCurrentStatus();
            return this;
        }
        public UseCaseConfiguration BuildCinemaTicketReservationService()
        {
            _buyCinemaTicket = new BuyCinemaTicket();
            return this;
        }
        public UseCaseConfiguration BuildCinemaHallValidationService()
        {
            _cinemaHallValidationService = new CinemaHallValidationService();
            return this;
        }
        public UseCaseConfiguration BuildCinemaHallStatisticsGenerationService()
        {
            _generateCinemaHallStatistics = new GenerateCinemaHallStatistics();
            return this;
        }

    }
}
