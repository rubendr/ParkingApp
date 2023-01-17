using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Models
{
    public class ParkingPayload
    {
        public int? Slot { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleColor { get; set; }
        public string? Status { get; set; }
    }
}
