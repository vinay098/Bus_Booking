using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.AppTables
{
    public class Seat
    {
        public Guid Id { get; set; }
        public Guid BusId { get; set; }
        public Bus Bus { get; set; }
        public string SeatNumber { get; set; }
        public Boolean IsBooked { get; set; }
    }
}