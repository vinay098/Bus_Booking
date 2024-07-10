
using Microsoft.AspNetCore.Identity;

namespace api.Models.AppTables
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}