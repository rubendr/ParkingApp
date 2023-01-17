using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IData
    {
        public bool CheckIn(ParkingModel parkingModel);
        public bool CheckOut(ParkingModel parkingModel);



    }
}
