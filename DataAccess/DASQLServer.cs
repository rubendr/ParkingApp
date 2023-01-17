using Dapper;
using DataAccess.Models;
using DataAccess.Query;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    /// <summary>
    /// Data Access using Dapper
    /// </summary>
    public class DASQLServer:IData
    {
        public string? ConnectionString { get; set; }
        public string Holla()
        {
            return "Halo Dapper";
        }
        public IQueryable<dynamic> GetAllParkingTrans()
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                var result = con.QueryAsync<dynamic>("select * from ParkingTrans").Result.AsQueryable().AsNoTracking();
                return result;
            }

        }

        public IQueryable<dynamic> GetAll()
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                var result = con.QueryAsync<dynamic>("select * from ParkingTrans").Result.AsQueryable().AsNoTracking();
                return result;
            }
        }

        public bool CheckIn(ParkingModel payload)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                var prm = new DynamicParameters(payload);
                if (payload.Status == "I")
                {
                    string sql = ParkingQuery.Insert;
                    var result = con.ExecuteScalar<long>(sql, prm);
                    if (result >= 0)
                        return true;
                }
                return false;
            }

        }

        public bool CheckOut(ParkingModel payload)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                var prm = new DynamicParameters(payload);
                if (payload.Status == "I")
                {
                    string sql = ParkingQuery.Update;
                    var result = con.ExecuteScalar<long>(sql, prm);
                    if (result >= 0)
                        return true;
                }

                return false;
            }
        }

        public object DeleteOne(object payload)
        {
            throw new NotImplementedException();
        }
    }
}