using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        [Key]
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleColor { get; set; }
    }
}
