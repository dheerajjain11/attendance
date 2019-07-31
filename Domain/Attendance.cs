using Domain.Base;
using DTO;
using System;

namespace Domain
{
    public class Attendance : EntityBase
    {
        public string PersonID { get; private set; }
        public AttendanceEntryType AttendanceEntry { get; private set; }
        public DateTime AttendanceDate { get; private set; }
        public virtual AttendanceEvent Event {get; private set;}
        protected Attendance()
        {
        }
        public Attendance(AttendanceEvent attendanceEvent)
        {
            this.Event = attendanceEvent;
        }
        public bool Mark(string personId, AttendanceEntryType entryType, DateTime dateTime)
        {
            this.PersonID = personId;
            this.AttendanceEntry = entryType;
            this.AttendanceDate = dateTime;
            return true;
        }
    }
}