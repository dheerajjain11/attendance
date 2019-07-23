using System;

namespace DTO
{
    public class MarkAttendanceDTO
    {
        public Guid AttendanceMachineId { get; set; }
        public long PersonId { get; set; }
        public AttendanceEntryType AttendanceEntry { get; set; }
        public DateTime Date { get; set; }
    }
}
