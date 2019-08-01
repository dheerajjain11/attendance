using Domain.Base;
using DTO;
using System;

namespace Domain
{
    public class Attendance : EntityBase
    {
        public string PersonID { get; protected set; }
        public AttendanceEntryType AttendanceEntry { get; protected set; }
        public DateTime AttendanceDate { get; protected set; }
        public virtual AttendanceEvent Event {get; protected set;}
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