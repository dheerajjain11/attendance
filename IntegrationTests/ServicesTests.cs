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
                AttendanceEvent = "Office Daily Attendance",
                IsMultiple = true
            });
        }

        [TestMethod]
        public void MarkAttendanceTest()
        {
            AttendanceService service = new AttendanceService(new AttendanceContext());
            MarkAttendanceDTO attendanceDTO = new MarkAttendanceDTO();
            Guid attendanceMachineId = Guid.Parse("F34F51AC-8805-4D5D-6C31-08D70E77F36E");
            attendanceDTO.AttendanceEntry = AttendanceEntryType.Present;
            attendanceDTO.PersonId = 123.ToString();
            attendanceDTO.Date = DateTime.Now;
            service.MarkAttendance(attendanceMachineId, attendanceDTO);
        }
    }
}
    