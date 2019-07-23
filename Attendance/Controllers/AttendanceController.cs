using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

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
        [HttpPost("createmachine")]
        public IActionResult CreateAttendanceMachine([FromBody] AttendanceMachineCreationDTO attendanceMachineCreationDTO)
        {
            Guid guid = attendanceService.CreateAttendanceMachine(attendanceMachineCreationDTO);
            if (guid == Guid.Empty && guid == null)
            {
                return BadRequest();
            }
            return Ok(guid.ToString());
        }

        [HttpPut("machine/{id}/mark")]
        public IActionResult MarkAttendance(string id, [FromBody] MarkAttendanceDTO markAttendanceDTO)
        {
            Guid machineId = Guid.Parse(id);
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
