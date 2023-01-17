using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Data Access using Store Procedure or Raw SQL
    /// </summary>
    public sealed class SPSQLServer : IData
    {
        public string? ConnectionString { get; set; }
        public string Holla()
        {
            return "Halo Store Procedure";
        }
        public IQueryable<ParkingModel> GetAllParkingTrans()
        {
            var result = new List<ParkingModel>();
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "sp_parkingtrans_get_all";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ParkingModel
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Slot = Convert.ToInt32(reader["Slot"]),
                        VehicleNo = reader["VehicleNo"].ToString(),
                        VehicleType = reader["VehicleType"].ToString(),
                        VehicleColor = reader["VehicleColor"].ToString()
                    });
                }
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
            }
            return result.AsQueryable().AsNoTracking();

        }

        public IQueryable<ParkingModel> GetAll()
        {
            var result = new List<ParkingModel>();
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "sp_parkingtrans_get_all";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ParkingModel
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Slot = Convert.ToInt32(reader["Slot"]),
                        VehicleNo = reader["VehicleNo"].ToString(),
                        VehicleType = reader["VehicleType"].ToString(),
                        VehicleColor = reader["VehicleColor"].ToString()
                    });
                }
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
            }
            return result.AsQueryable().AsNoTracking();
        }

        public bool CheckIn(ParkingModel parkingModel)
        {
            using var con = new SqlConnection(ConnectionString);            
            var cmd = new SqlCommand();
            cmd.CommandText = "sp_parkingtrans_checkin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters["@slot"].Value = parkingModel.Slot;
            cmd.Parameters["@vehicleNo"].Value = parkingModel.VehicleNo;
            cmd.Parameters["@vehicleType"].Value = parkingModel.VehicleType;
            cmd.Parameters["@vehicleColor"].Value = parkingModel.VehicleColor;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            if (result > 0)
                return true;
            return false;
        }

        public bool CheckOut(ParkingModel parkingModel)
        {
            using var con = new SqlConnection(ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandText = "sp_parkingtrans_checkout";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters["@Id"].Value = parkingModel.Id;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            if (result > 0)
                return true;
            return false;
        }
    }
}
