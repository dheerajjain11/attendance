using System;

namespace DTO
{
    public class MarkAttendanceRealDTO
    {
        public string PersonName { get; set; }
        public string EventName { get; set; }
        public AttendanceEntryType AttendanceEntry { get; set; }
        public DateTime Date { get; set; }
    }
}
