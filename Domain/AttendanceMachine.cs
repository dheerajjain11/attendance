using Domain.Base;
using DTO;
using System;
using System.Collections.Generic;

namespace Domain
{
    // public delegate void AttendanceMarkEventHandler(); 

    public class AttendanceMachine : EntityBase
    {
        private ICollection<AttendanceItem> _attendanceItems = null;
        public virtual string AttendanceEvent { get; private set; }
        public virtual TimeSpan Duration { get; private set; }
        public virtual bool AllowMultiple { get; private set; }

        public virtual ICollection<AttendanceItem> Attendances
        {
            get
            {
                if (_attendanceItems == null)
                {
                    _attendanceItems = new List<AttendanceItem>();
                }
                return _attendanceItems;
            }
            private set { _attendanceItems = value; }
        }

        public AttendanceMachine()
        {
        }

        public AttendanceMachine(string attendanceEvent, TimeSpan timeSpan, bool allowMultiple)
        {
            this.AttendanceEvent = attendanceEvent;
            this.Duration = timeSpan;
            this.AllowMultiple = AllowMultiple;
            this.Attendances = new List<AttendanceItem>();
        }

        public AttendanceMachine(string attendanceEvent, bool allowMultiple)
        {
            this.AttendanceEvent = attendanceEvent;
            this.AllowMultiple = allowMultiple;
            this.Attendances = new List<AttendanceItem>();
        }

        public bool Mark(long personId, AttendanceEntryType entryType, DateTime dateTime)
        {
            this.Attendances.Add(new AttendanceItem
            {
                AttendanceDate = dateTime.Date,
                PersonID = personId,
                AttendanceEntry = entryType
            });
            return true;
        }
    }
}
