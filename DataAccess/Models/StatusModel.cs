using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? StatusDesc { get; set; }
    }
}
