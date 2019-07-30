using System;
using System.Collections.Generic;
using System.Linq;
using MeetingTestApi.Entities;
using MeetingTestApi.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

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
        // GET Meetings/Meetings
        public IActionResult ListMeetings()
        {
            var listMeetings =
                from a in db.TblMeetings
                join b in db.TblDays
                    on a.IdDay equals b.IdDay
                join c in db.TblTimeslots
                    on a.IdTimeslot equals c.IdTimeslot
                select new ModelMeetingFinal
                {
                    IdMeeting = a.IdMeeting,
                    Day = b.Day,
                    StartTime = c.StartTime,
                    EndTime = c.EndTime
                };
            return Ok(listMeetings);
        }

        [Route("MeetingsTable")]
        // GET Meetings/MeetingsTable
        public IActionResult ListMeetingsID()
        {
            var listMeetings = db.TblMeetings
                .Select(c => c)
                .ToList();
            return Ok(listMeetings);
        }

        //[Route("Meetings/{id}")]
        [HttpGet("{id}", Name = "GetMeeting")]
        // GET Meetings/Meetings/1
        public IActionResult getMeetingById(int id)
        {
            var meetingById = db.TblMeetings
                .Where(c => c.IdMeeting == id)
                  .Select(d => new ModelMeeting
                  {
                      IdMeeting = d.IdMeeting,
                      IdDay = d.IdDay,
                     IdTimeslot = d.IdTimeslot
                  }).ToList();
            return Ok(meetingById);
        }

        #region POST methods (creating new resources)
        [HttpPost]
        [Route("AddMeeting")]
        public IActionResult AddMeeting([FromBody] ModelMeeting content)
        {    
            TblMeetings meet = new TblMeetings
            {
               IdDay = content.IdDay,
               IdTimeslot = content.IdTimeslot
             };

             db.TblMeetings.Add(meet);
             db.SaveChanges();
            return Created(Url.Link("GetMeeting", new { id = meet.IdMeeting }), meet);
        }
        #endregion








        #region Testing Purposes
        [HttpPost]
        [Route("addSimpleString")]
        public string JsonStringBody([FromBody] string content)
        {
            // Looks for a string in json format
            Debug.WriteLine(content);
            return content;
        }

        // public HttpResponseMessage Add(ModelMeeting meeting)
        // {
        //  TblMeetings meet = new TblMeetings
        //     {
        //  IdMeeting = meeting.IdMeeting,
        //  IdDay = meeting.IdDay,
        //  IdTimeslot = meeting.IdTimeslot
        //  };

        //  db.TblMeetings.Add(meet);
        // db.SaveChanges();

        // var response = Request.CreateResponse<HttpStatusCode.Created, Item>

        // return Response.Headers.Location();
        #endregion
    }

}
