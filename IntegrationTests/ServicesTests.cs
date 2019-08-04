using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using Services;
using Persistence;
using System;

namespace IntegrationTests
{
    [TestClass]
    public class ServicesTests
    {
        [TestMethod]
        public void CreateAttendanceMachineTest()
        {
            AttendanceService service = new AttendanceService(new AttendanceContext());
            service.CreateAttendanceMachine(new AttendanceMachineCreationDTO
            {
                AttendanceEvent = "Hello attendance",
                IsMultiple = true
            });
        }

        [TestMethod]
        public void MarkAttendanceTest()
        {
            AttendanceService service = new AttendanceService(new AttendanceContext());
            MarkAttendanceDTO attendanceDTO = new MarkAttendanceDTO();
            Guid attendanceMachineId = Guid.Parse("3D15C1B9-9337-4341-223A-08D718A2C2AE");
            attendanceDTO.AttendanceEntry = AttendanceEntryType.Present;
            attendanceDTO.PersonId = 123.ToString();
            attendanceDTO.Date = DateTime.Now;
            service.MarkAttendance(attendanceMachineId, attendanceDTO);
        }
    }
}
    