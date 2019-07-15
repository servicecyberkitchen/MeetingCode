using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingTestApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeslotsController : ControllerBase
    {
        AppointmentsContext db = new AppointmentsContext();

        [HttpGet("ListAllTimeslots")]
        public IActionResult ListAllTimeslots()
        {
            var listTimeslots = db.TblTimeslots
                .Select(c => c)
                .ToList();
            return Ok(listTimeslots);
        }

        [HttpGet("ListFirstTimeslot")]
        public IActionResult ListFirstTimeslot()
        {
            var listFirstTimeslot = db.TblTimeslots
                .Select(c => c)
                .FirstOrDefault();
            return Ok(listFirstTimeslot);
        }
    }
}