using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.AppTables
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid RouteId { get; set; }
        public BusRoute Route { get; set; }
        public DateTime DepatureDateTime { get; set; }
        public DateTime ArrivalDateTime { get;set; }
        public double TotalFare { get; set; }
        public ICollection<Payment> BookingPayments { get; set; }
    }
}