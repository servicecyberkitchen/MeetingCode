using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetingTestMvc.Models;
using System.Net.Http;
using MeetingTestApi.Models;
using Newtonsoft.Json;

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
        public ActionResult ShowInfo()
        {
            return View();
        }

        [Route("[action]")]
        public ActionResult ShowReservationPage()
        {
            return View("AddReservation");
        }

    }
}
