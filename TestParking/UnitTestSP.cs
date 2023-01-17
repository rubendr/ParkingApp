using NUnit.Framework;

namespace ParkingTestProject
{
    public class TestSP
    {
        private DataAccess.SPSQLServer db;
        private string cs;
        [SetUp]
        public void Setup()
        {
            db = new DataAccess.SPSQLServer();
            cs = "Data Source=.;Initial Catalog=ParkingDb;Integrated Security=True;TrustServerCertificate=True";
            db.ConnectionString= cs;
        }

        [Test]
        public void TestConnection()
        {
            string actualResult = db.Holla();
            Assert.That(actualResult, Is.SameAs("Halo Store Procedure"));
        }

        [Test]
        public void TestCheckIn()
        {
            bool actual = db.CheckIn(new DataAccess.Models.ParkingModel
            {
                Id = DateTime.Now.Ticks,
                Slot = 3,
                Status = "I",
                VehicleColor = "White",
                VehicleNo = "S-12345-P",
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
                Id = 3,
                Status="I"
            });

            Assert.That(actual, Is.EqualTo(true));
        }


    }
}