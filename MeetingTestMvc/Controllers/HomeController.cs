using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MeetingTestApi.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MeetingTestMvc.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:2019")
            };
        }

        [Route("")]
        [Route("[action]")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [Route("[action]")]
        public ActionResult Create()
        {
            string dayResult = _client.GetStringAsync("days/days").Result;
            List<ModelDay> dayList = JsonConvert.DeserializeObject<List<ModelDay>>(dayResult);

            string timeslotResult = _client.GetStringAsync("timeslots/timeslots").Result;
            List<ModelTimeslot> timeslotList = JsonConvert.DeserializeObject<List<ModelTimeslot>>(timeslotResult);

            ViewBag.days = dayList;
            ViewBag.timeslots = timeslotList;

            return View(ViewBag);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddMeetingAsync()
        {
            int day = Int32.Parse(Request.Form["day"]);
            int timeslot = Int32.Parse(Request.Form["timeslot"]);

            ModelMeeting newMeeting = new ModelMeeting()
            {
                IdDay = day,
                IdTimeslot = timeslot
            };

            HttpResponseMessage response = await _client.PostAsJsonAsync
                ("Meetings/AddMEeting", newMeeting);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("ShowListOfMeetings", "Admin");
        }









        #region Usefull Code    
        [Route("[action]")]
        public async Task<Uri> CreateMeetingAsync()
        {
            Debug.WriteLine("TestCreate");
            string test = "test";
            HttpResponseMessage response = await _client.PostAsJsonAsync
                ("Meetings/addSimpleString", test);
            Debug.WriteLine("TestCreate2");
            return response.Headers.Location;
        }
        [Route("[action]")]
        public async System.Threading.Tasks.Task<ActionResult> addedAsync()
        {
            int day = Int32.Parse(Request.Form["day"]);
            int timeslot = Int32.Parse(Request.Form["day"]);

            ViewBag.day = day;
            ViewBag.timeslot = timeslot;

            ModelMeeting newMeeting = new ModelMeeting()
            {
                IdDay = day,
                IdTimeslot = timeslot
            };

            ViewBag.newMeeting = newMeeting;

            var endpoint = "http://localhost:2019/Meeting/AddMeeting";
            var response = _client.PostAsJsonAsync(endpoint, newMeeting);

            ViewBag.resp = response;

            return View("Add", ViewBag);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<Uri> AddAsyncOld()
        {
            int day = Int32.Parse(Request.Form["day"]);
            int timeslot = Int32.Parse(Request.Form["timeslot"]);

            ModelMeeting newMeeting = new ModelMeeting()
            {
                IdDay = day,
                IdTimeslot = timeslot
            };

            HttpResponseMessage response = await _client.PostAsJsonAsync
                ("Meetings/Post", newMeeting);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        #endregion
    }
}
