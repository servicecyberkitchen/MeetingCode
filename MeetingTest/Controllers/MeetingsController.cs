using System;
using System.Collections.Generic;
using System.Linq;

using MeetingTestApi.Entities;
using MeetingTestMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        AppointmentsContext db;
        public MeetingsController()
        {
            db = new AppointmentsContext();
        }

        [Route("Meetings")]
        public IActionResult ListMeetings()
        {
            var listMeetings =
                from a in db.TblMeetings
                join b in db.TblDays
                    on a.IdDay equals b.IdDay
                join c in db.TblTimeslots
                    on a.IdTimeslot equals c.IdTimeslot
                select new FinalMeeting
                {
                    IdMeeting = a.IdMeeting,
                    Day = b.Day,
                    StartTime = c.StartTime,
                    EndTime = c.EndTime
                };
            return Ok(listMeetings);
        }

        [Route("MeetingsTable")]
        // GET Meetings/Meetings
        public IActionResult ListMeetingsID()
        {
            var listMeetings = db.TblMeetings
                .Select(c => c)
                .ToList();
            return Ok(listMeetings);
        }

        [Route("AddMeeting")]
        public IActionResult AddMeeting()
        {
            TblMeetings newMeeting = new TblMeetings()
            {
                IdDay = 1,
                IdTimeslot = 2
            };

            db.TblMeetings.Add(newMeeting);
            db.SaveChanges();

            return ListMeetings();
        }


        #region Testing Purposes


        #endregion
    }
}