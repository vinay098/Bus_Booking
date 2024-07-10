using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.AppTables
{
    public class BusRoute
    {
        public Guid Id { get; set; }
        public String Source { get; set; }
        public String Destination { get; set; }
        public float distance { get; set; }
        public float duration { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}