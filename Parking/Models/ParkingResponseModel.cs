namespace Parking.Models
{
    public class ParkingResponseModel
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
