﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface IInitializeCinemaHall
    {
        int[][] Initialize(string noOfRows, string noOfSeats);
    }
}
