using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AttendanceEventDTO
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public bool IsMultiple { get; set; }
    }
}
