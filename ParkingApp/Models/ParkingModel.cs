using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Models
{
    public sealed class ParkingModel
    {
        [Key]
        public long? Id { get; set; }
        public int? Slot { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleColor { get; set; }
        public string? Status { get; set; }
        

    }
}
