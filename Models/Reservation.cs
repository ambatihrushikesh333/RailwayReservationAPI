namespace RailwayReservationAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public string? MobileNumber { get; set; }

        public string? JourneyStart { get; set; }

        public string? JourneyEnd { get; set; }
    }
}
