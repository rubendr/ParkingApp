using NUnit.Framework;

namespace ParkingTestProject
{
    public class TestDapper
    {

        private string cs;
        private DataAccess.DASQLServer db;
        [SetUp]
        public void Setup()
        {
            db = new DataAccess.DASQLServer();
            cs = "Data Source=.;Initial Catalog=ParkingDb;Integrated Security=True;TrustServerCertificate=True";
            db.ConnectionString = cs;
        }

        [Test]
        public void TestConnection()
        {
            string actualResult = db.Holla();
            Assert.That(actualResult, Is.SameAs("Halo Dapper"));
        }

        [Test]
        public void TestCheckIn()
        {
            bool actual = db.CheckIn(new DataAccess.Models.ParkingModel
            {
                Id = DateTime.Now.Ticks,
                Slot = 1,
                Status = "I",
                VehicleColor = "White",
                VehicleNo = "D-1234-PR",
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
                Id = 1,
                Status="I"
            });
            Assert.That(actual, Is.EqualTo(true));
        }




    }
}