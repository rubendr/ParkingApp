using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) { }

        public DbSet<ParkingModel> ParkingTrans { get; set; }
        public DbSet<VehicleModel> VehicleTable { get; set; }
        public DbSet<StatusModel> StatusTable { get; set; }

    }
}
