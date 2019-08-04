using Domain.Base;
using DTO;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class AttendanceEvent : EntityBase
    {
        public virtual string EventName { get; protected set; }
        public virtual TimeSpan Duration { get; protected set; }
        public virtual bool AllowMultiple { get; protected set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public AttendanceEvent()
        {
        }

        public AttendanceEvent(string attendanceEvent, TimeSpan timeSpan, bool allowMultiple)
        {
            this.EventName = attendanceEvent;
            this.Duration = timeSpan;
            this.AllowMultiple = AllowMultiple;
        }

        public AttendanceEvent(string attendanceEvent, bool allowMultiple)
        {
            this.EventName = attendanceEvent;
            this.AllowMultiple = allowMultiple;
        }

        public bool Mark(string personId, AttendanceEntryType entryType, DateTime dateTime)
        {
            Attendance attendance = new Attendance(this, personId);
            attendance.Mark();
            this.Attendances.Add(attendance);
            return true;
        }
    }
}
