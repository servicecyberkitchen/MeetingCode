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
        AppointmentsContext db;
        public TimeslotsController()
        {
            db = new AppointmentsContext();
        }

        [Route("Timeslots")]
        // GET Days/Days
        public IActionResult ListTimeslots()
        {
            var listTimeslots = db.TblTimeslots
                .Select(c => c)
                .ToList();
            return Ok(listTimeslots);
        }

        [Route("Timeslots/{id}")]
        // GET Timeslots/Timeslots/1
        public IActionResult getTimeslotById(int id)
        {
            var timeslotById = db.TblTimeslots
                .Where(c => c.IdTimeslot == id)
                .Select(c => c);
            return Ok(timeslotById);
        }
    }
}