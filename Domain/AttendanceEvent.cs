using Domain.Base;
using DTO;
using System;
using System.Collections.Generic;

namespace Domain
{
    // public delegate void AttendanceMarkEventHandler(); 

    public class AttendanceEvent : EntityBase
    {
        private ICollection<Attendance> _attendanceItems = null;
        public virtual string EventName { get; private set; }
        public virtual TimeSpan Duration { get; private set; }
        public virtual bool AllowMultiple { get; private set; }

        //public virtual ICollection<Attendance> Attendances
        //{
        //    get
        //    {
        //        if (_attendanceItems == null)
        //        {
        //            _attendanceItems = new List<Attendance>();
        //        }
        //        return _attendanceItems;
        //    }
        //    private set { _attendanceItems = value; }
        //}

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

    }
}
