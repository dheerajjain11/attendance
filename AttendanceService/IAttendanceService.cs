using DTO;
using System;

namespace Services
{
    public interface IAttendanceService
    {
        void MarkAttendance(Guid machineId, MarkAttendanceDTO attendanceDTO);
        Guid CreateAttendanceMachine(AttendanceMachineCreationDTO attendanceMachineCreationDTO);
        AttendanceEventDTO GetAttendanceEvent(string name);
    }
}