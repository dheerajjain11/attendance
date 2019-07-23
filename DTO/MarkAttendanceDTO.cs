using System;

namespace DTO
{
    public class MarkAttendanceDTO
    {
        public long PersonId { get; set; }
        public AttendanceEntryType AttendanceEntry { get; set; }
        public DateTime Date { get; set; }
    }
}
