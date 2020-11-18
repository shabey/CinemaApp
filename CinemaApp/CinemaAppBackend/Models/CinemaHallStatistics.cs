using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    public class CinemaHallStatistics
    {
        /*
         * Output metrics for the cinema room, including:
            Number of purchased tickets
            Percentage occupied
            Current income (sum of reserved tickets)
            Potential total income (sum of all available and reserved tickets)
         */

        public int NumberOfPurchasedTickets { get; set; }
        public float PercentageOccupied { get; set; }
        public float CurrentIncome { get; set; } // Current income (sum of reserved tickets)
        public float PotentialTotalIncome { get; set; } // Potential total income (sum of all available and reserved tickets)
        public int TotalNumbersOfSeats { get; set; }
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Current output metrics for the cinema room");
            output.AppendLine();
            output.AppendLine($"Number of purchased tickets: {this.NumberOfPurchasedTickets} out of {this.TotalNumbersOfSeats}");
            output.AppendLine();
            output.AppendLine($"Percentage occupied: {this.PercentageOccupied:P2}");
            output.AppendLine();
            output.AppendLine($"Current income (sum of reserved tickets): {this.CurrentIncome:F2}");
            output.AppendLine();
            output.AppendLine($"Potential total income (sum of all available and reserved tickets): {this.PotentialTotalIncome:F2}");
            return output.ToString();
        }
    }
}
