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

        [HttpGet("ListAllDays")]
        public ActionResult<IEnumerable<ModelDay>> ListAllDays()
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

        [HttpGet("ListFirstDay")]
        public IActionResult ListFirstDay()
        {
            var listFirstDay = db.TblDays
                .Select(c => c)
                .FirstOrDefault();
            return Ok(listFirstDay);
        }
    }
}