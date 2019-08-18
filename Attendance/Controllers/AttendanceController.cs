using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceService attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values

        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getevent")]
        public IActionResult Get(string eventName)
        {
            return Ok(attendanceService.GetAttendanceEvent(eventName));
        }
      
        [HttpPost("createevent")]
        public IActionResult CreateAttendanceEvent([FromBody] AttendanceMachineCreationDTO attendanceMachineCreationDTO)
        {
            Guid guid = attendanceService.CreateAttendanceMachine(attendanceMachineCreationDTO);
            if (guid == Guid.Empty && guid == null)
            {
                return BadRequest();
            }
            return Ok(guid.ToString());
        }

        //public IActionResult Mark(MarkAttendanceRealDTO realDTO)
        //{
        //    attendanceService.MarkAttendance(realDTO);
        //    return Ok();
        //}

        [HttpPut("attendance/{eventid}/mark")]
        public IActionResult MarkAttendance(string eventid, [FromBody] MarkAttendanceDTO markAttendanceDTO)
        {
            Guid machineId = Guid.Parse(eventid);
            if(machineId==null || machineId==Guid.Empty)
            {
                return BadRequest("Invalid Parameter");
            }
            attendanceService.MarkAttendance(machineId, markAttendanceDTO);
            return Ok();
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
