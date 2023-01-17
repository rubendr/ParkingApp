using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingDesktop
{
    internal class ResponseModel
    {
        public string? Message { get; set; }
        public bool? Success { get; set; }
        public object? Data { get; set; }
    }
}
