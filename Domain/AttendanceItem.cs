using Domain.Base;
using DTO;
using System;

namespace Domain
{
    public class AttendanceItem : EntityBase
    {
        public long PersonID { get; set; }
        public AttendanceEntryType AttendanceEntry { get; set; }
        public DateTime AttendanceDate { get; set; }
        public virtual AttendanceMachine Machine {get; set;}
    }
}