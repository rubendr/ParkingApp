using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private const string _csname = "parkingdb";
        private readonly IConfiguration _config;
        private readonly DataAccess.DASQLServer _db; // dapper
        private readonly DataAccess.EFSQLServer _efdb; // EF
        private readonly DataAccess.SPSQLServer _spdb; // SP
        private string _connectionString;

        public ParkingController(
            IConfiguration configuration,
            DataAccess.DASQLServer db,
            DataAccess.EFSQLServer efdb,
            DataAccess.SPSQLServer spdb
            )
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString(_csname)!;
            // Dapper
            _db = db;
            _db.ConnectionString = _connectionString;
            // EF
            _efdb = efdb;
            _efdb.ConnectionString = _connectionString;
            // SP
            _spdb = spdb;
            _spdb.ConnectionString = _connectionString;
        }

        [HttpGet]
        public Task Get()
        {
            //var result = new Dictionary<string, object>();
            var result = new ParkingResponseModel();
            try
            {
                var data = _db.GetAllParkingTrans();
                result.Message = "OK";
                result.Data = data;
                result.Success = true;
                return Response.WriteAsJsonAsync(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Data = null;
                result.Success = false;
                return Response.WriteAsJsonAsync(result);
            }
        }

        [HttpGet("{id}")]
        public Task Get(Int64 id)
        {
            var result = _efdb.GetAllParking().Where(w => w.Id == id);
            return Response.WriteAsJsonAsync(result);
        }


        [HttpGet("sp/{id}")]
        public Task GetByStoreProcedure(Int64 id)
        {
            var result = _spdb.GetAllParkingTrans().Where(w => w.Id == id);
            return Response.WriteAsJsonAsync(result);
        }


        [HttpGet(nameof(GetAllData))]
        public Task GetAllData()
        {
            var result = new Dictionary<string, object>();
            var dapperTask = Task.Factory.StartNew(() => _db.GetAll());
            var efTask = Task.Factory.StartNew(() => _efdb.GetAll());
            var spTask = Task.Factory.StartNew(() => _spdb.GetAll());
            var tasks = new List<Task>();
            tasks.Add(dapperTask);
            tasks.Add(efTask);
            tasks.Add(spTask);
            Task.WhenAll(tasks);
            result.Add("Dapper", dapperTask.Result);
            result.Add("EF", efTask.Result);
            result.Add("SP", spTask.Result);
            return Response.WriteAsJsonAsync(result);
        }


        [HttpPost]
        public Task Post([FromBody] ParkingModel payload)
        {
            //var result = new Dictionary<string, object>();
            var result = new ParkingResponseModel();
            try
            {
                var isPosted = _db.CheckIn(payload);
                result.Success = isPosted;
                result.Message = "OK";
                result.Data = null;
                //Response.StatusCode = (int)HttpStatusCode.Created;
                return Response.WriteAsJsonAsync(result);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
                //Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Response.WriteAsJsonAsync(result);
            }
        }

        [HttpPut()]
        public void Put([FromBody] ParkingModel payload)
        {
            var result = _db.CheckOut(payload);
            Console.WriteLine(result);

            Response.WriteAsJsonAsync(result);
        }

        [HttpDelete()]
        public void Delete(ParkingModel payload)
        {
            var result = _db.DeleteOne(payload);
            Response.WriteAsJsonAsync(result);
        }
    }
}
