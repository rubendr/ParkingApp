using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ParkingTestProject
{
    public class TestEF
    {
        private DataAccess.EFSQLServer db;
        private DataAccess.ParkingContext ctx;
        private string cs;
        [SetUp]
        public void Setup()
        {
            cs = "Data Source=.;Initial Catalog=ParkingDb;Integrated Security=True;TrustServerCertificate=True";
            var opt = new DbContextOptionsBuilder<DataAccess.ParkingContext>().UseSqlServer(cs).Options;
            ctx = new DataAccess.ParkingContext(opt);
            db = new DataAccess.EFSQLServer(ctx);

        }

        [Test]
        public void TestConnection()
        {
            string actualResult = db.Holla();
            Assert.That(actualResult, Is.SameAs("Halo Entity Framework"));
        }

        [Test]
        public void TestCheckIn()
        {
            bool actual = db.CheckIn(new DataAccess.Models.ParkingModel
            {
                Slot = 2,
                Status = "I",
                VehicleColor = "White",
                VehicleNo = "E-1234-F",
                VehicleType = "Car",
                DateTimeIn = DateTime.Now
            });
            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void TestCheckOut()
        {
            bool actual = db.CheckOut(new DataAccess.Models.ParkingModel
            {
                Id = 2,
                Status = "I"
            });

            Assert.That(actual, Is.EqualTo(true));
        }


    }
}