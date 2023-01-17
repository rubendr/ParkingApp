using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Data Access using Entity Framework
    /// </summary>
    public sealed class EFSQLServer:IData
    {
        public string? ConnectionString { get; set; }
        private readonly ParkingContext _db;
        public EFSQLServer(ParkingContext db)
        {
            _db = db;
        }
        public string Holla()
        {
            return "Halo Entity Framework";
        }
        public IQueryable<ParkingModel> GetAllParking()
        {
            return _db.ParkingTrans.AsQueryable();
        }

        public IQueryable<ParkingModel> GetAll()
        {
            return _db.ParkingTrans.AsQueryable();
        }

        public bool CheckIn(ParkingModel parkingModel)
        {
            if (parkingModel.Status == "I")
            {
                _db.Add(parkingModel);
                var result = _db.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }

        public bool CheckOut(ParkingModel parkingModel)
        {
            if (parkingModel.Status == "I")
            {
                var updatedata = _db.ParkingTrans.Where(w => w.Id == parkingModel.Id).First();
                updatedata.Status = "O";
                updatedata.DateTimeOut = DateTime.Now;
                var result = _db.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }
    }
}
