using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeetingTestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingTestMvc.Controllers
{
    [Route("[controller]")]
    public class DaysController : Controller
    {
        private HttpClient _client;
        public DaysController()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:2019")
            };
        }

        [HttpGet("ListAllDays")]
        public ActionResult ListAllDays()
        {
            string eventResult = _client.GetStringAsync("Days/days").Result;
            List<ModelDay> eventsList = JsonConvert.DeserializeObject<List<ModelDay>>(eventResult);
            return Ok(eventsList);
        }
    }
}