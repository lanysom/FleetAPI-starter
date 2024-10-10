namespace FleetAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public required string Brand { get; set; }
        public required string Fuel { get; set; }
        public required int Capacity { get; set; }
        public int Kilometers { get; set; }
        public string Status { get; set; } = STATUS_AVAILABLE;

        public const string STATUS_AVAILABLE = "available";
        public const string STATUS_RENTED = "rented";
    }
}
