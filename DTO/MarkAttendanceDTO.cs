using System;

namespace DTO
{
    public class MarkAttendanceDTO
    {
        public string PersonId { get; set; }
        public AttendanceEntryType AttendanceEntry { get; set; }
        public DateTime Date { get; set; }
    }
}
