using DTO;
using Persistence;
using System;
using Domain;
using System.Linq;

namespace Services
{
    public class AttendanceService : IAttendanceService
    {
        private AttendanceContext context;
        public AttendanceService(AttendanceContext context)
        {
            this.context = context;
            context.ChangeTracker.LazyLoadingEnabled = false;
        }
        public void MarkAttendance(Guid machineId, MarkAttendanceDTO attendanceDTO)
        {
            /*
             * 1. Get the domain
             * 2. Let domain handle calls
             * 3. Persist the changes
             */
            AttendanceEvent attendanceMachine = 
                context.AttendanceEvents.Find(machineId);
            attendanceMachine.Mark(attendanceDTO.PersonId, attendanceDTO.AttendanceEntry, attendanceDTO.Date);
            context.SaveChanges();
        }

        public Guid CreateAttendanceMachine(AttendanceMachineCreationDTO attendanceMachineCreationDTO)
        {
            AttendanceEvent attendanceMachine = new AttendanceEvent(
                                                        attendanceMachineCreationDTO.AttendanceEvent,
                                                        true);
            context.AttendanceEvents.Add(attendanceMachine);
            context.SaveChanges();
            return attendanceMachine.Id;
        }

        public AttendanceEventDTO GetAttendanceEvent(string name)
        {
            return (from e in context.Set<AttendanceEvent>() where e.EventName.Equals(name)
            select new AttendanceEventDTO
            {
                EventId = e.Id,
                EventName = e.EventName,
                IsMultiple = e.AllowMultiple
            }).FirstOrDefault();
        }
    }
}
