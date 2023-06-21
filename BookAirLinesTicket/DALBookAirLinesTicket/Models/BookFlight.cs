using System;
using System.Collections.Generic;

namespace DALBookAirLinesTicket.Models
{
    public partial class BookFlight
    {
        public int BookingId { get; set; }
        public string? PassengerName { get; set; }
        public int? NoOfTicket { get; set; }
        public string? FlightNo { get; set; }
    }
}
