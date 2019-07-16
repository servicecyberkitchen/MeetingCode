using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeetingTestApi.Models;
using MeetingTestMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingTestMvc.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private HttpClient _client;
        public AdminController()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:2019")
            };
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("Meetings")]
        public IActionResult ShowListOfMeetings()
        {
            string meetingsResult = _client.GetStringAsync("Meetings/Meetings").Result;
            List<FinalMeeting> meetingsList = JsonConvert.DeserializeObject<List<FinalMeeting>>(meetingsResult);

            ViewBag.meetings = meetingsList;
            return View("Meetings", ViewBag);
        }
    }
}