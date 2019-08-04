using Domain.Base;
using DTO;
using System;

namespace Domain
{
    public class Attendance : EntityBase
    {
        public string PersonID { get; internal set; }
        public AttendanceEntryType AttendanceEntry { get; internal set; }
        public DateTime AttendanceDate { get; internal set; }
        public virtual AttendanceEvent Event {get; internal set;}
        protected Attendance()
        {
        }
        internal Attendance(AttendanceEvent attendanceEvent, string personId)
        {
            this.Event = attendanceEvent;
            this.PersonID = personId;
        }

        //default setter
        internal bool Mark()
        {
            this.AttendanceEntry = AttendanceEntryType.Present;
            this.AttendanceDate = DateTime.Now.Date;
            return true;
        }
    }
}