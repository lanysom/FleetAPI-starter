namespace FleetAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }
        public string Status { get; set; } = STATUS_AVAILABLE;

        public const string STATUS_AVAILABLE = "available";
        public const string STATUS_RENTED = "rented";
    }
}
