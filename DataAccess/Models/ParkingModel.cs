using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public sealed class ParkingModel
    {
        [Key]
        public long? Id { get; set; }
        public int? Slot { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleColor { get; set; }
        // Check In Code I(In) or O(Out)
        public string? Status { get; set; }
        public DateTime? DateTimeIn { get; set; }
        public DateTime? DateTimeOut { get; set;}

    }

}
