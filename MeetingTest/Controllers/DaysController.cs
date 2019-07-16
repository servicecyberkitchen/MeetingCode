using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingTestApi.Entities;
using MeetingTestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {   
        AppointmentsContext db;
        public DaysController()
        {
            db = new AppointmentsContext();
        }

        [Route("Days")]
        // GET Days/Days
        public ActionResult<IEnumerable<ModelDay>> ListDays()
        {
            try
            {
                IEnumerable<ModelDay> listDays = db.TblDays
                    .Select(d => new ModelDay
                    {
                        IdDay = d.IdDay,
                        Day = d.Day
                    })
                    .ToList();

                if (listDays == null || listDays.Count() == 0)
                    return NotFound("No days were found.");

                return Ok(listDays);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("Days/{id}")]
        // GET Days/Days/1
        public IActionResult getDayById(int id)
        {
            var dayById = db.TblDays
                .Where(c => c.IdDay == id)
                .Select(c => c);            
            return Ok(dayById);
        }
    }
}