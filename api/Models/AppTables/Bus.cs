using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.AppTables
{
    public class Bus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BusNumber { get; set; }
        public int Capacity { get; set; }
        public string BusType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}