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
    public class MeetingsController : ControllerBase
    {
        AppointmentsContext db = new AppointmentsContext();

        [HttpGet("ListAllMeetings")]
        public IActionResult ListAllMeetings()
        {
            var listMeetings = db.TblMeetings
                .Select(c => c)
                .ToList();
            return Ok(listMeetings);
        }

        [HttpGet("AddMeeting")]
        public IActionResult AddMeeting()
        {
            TblMeetings newMeeting = new TblMeetings()
            {
                IdDay = 1,
                IdTimeslot = 2
            };

            db.TblMeetings.Add(newMeeting);
            db.SaveChanges();

            return ListAllMeetings();
        }

    }
}