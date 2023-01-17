using Microsoft.AspNetCore.Mvc;
using ParkingWeb.Models;

namespace ParkingWeb.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ParkingServiceController : ControllerBase
    {
        private IHttpClientFactory httpClientFactory;
        public ParkingServiceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var client = httpClientFactory.CreateClient();
            var link = new Uri("http://localhost:9999/api/parking");
            var resp = client.GetStringAsync(link).Result;
            return new string[] { "value1", "value2", resp };
        }

        [HttpPost]
        public IEnumerable<string> PostData1([FromBody] ParkingPayload payload)
        {
            var client = httpClientFactory.CreateClient();
            var link = new Uri("http://localhost:9999/api/parking");
            var resp = client.GetStringAsync(link).Result;
            return new string[] { "value1", "value2", resp };
        }


        [HttpPost("checkin")]
        public IResult PostCheckIn([FromBody] ParkingPayload payload)
        {
            var client = httpClientFactory.CreateClient();
            var link = new Uri("http://localhost:9999/api/parking");
            var json = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var resp = client.PostAsync(link, content).Result;
            resp.EnsureSuccessStatusCode();
            var resultok=new Dictionary<string, object>();
            if (resp.IsSuccessStatusCode)
            {
                var respok = resp.Content.ReadFromJsonAsync<ParkingResponse>().Result;
                if (respok?.Success == true)
                {
                    resultok.Add("httpinfo", resp);
                    resultok.Add("respok", respok);
                    resultok.Add("message", "OK");
                    return Results.Ok(resultok);
                }
                else
                {
                    resultok.Add("httpinfo", resp);
                    resultok.Add("respok", respok!);
                    resultok.Add("message", respok!.Message);
                    return Results.Ok(resultok);
                }
            }
            return Results.Ok(resp.Content.ReadAsStringAsync().Result);

        }

        [HttpPost("checkout")]
        public IResult PostCheckOut([FromBody] ParkingPayload payload)
        {
            //var client = httpClientFactory.CreateClient();
            //var link = new Uri("http://localhost:9999/api/parking");
            //var content=new StringContent(value,System.Text.Encoding.UTF8,"application/json");
            //var resp = client.PostAsync(link,content).Result;
            //return Results.Ok(resp);
            return Results.Ok(payload);

        }
    }
}
