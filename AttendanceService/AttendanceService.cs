using DTO;
using Persistence;
using System;
using Domain;

namespace Services
{
    public class AttendanceService
    {
        private AttendanceContext context;
        public AttendanceService(AttendanceContext context)
        {
            this.context = context;
            context.ChangeTracker.LazyLoadingEnabled = false;
        }
        public void MarkAttendance(MarkAttendanceDTO attendanceDTO)
        {
            /*
             * 1. Get the domain
             * 2. Let domain handle calls
             * 3. Persist the changes
             */
            AttendanceMachine attendanceMachine = 
                context.AttendanceMachines.Find(attendanceDTO.AttendanceMachineId);

            if(attendanceMachine!=null)
            {
                attendanceMachine.Mark(attendanceDTO.PersonId, attendanceDTO.AttendanceEntry, attendanceDTO.Date);
            }
            context.SaveChanges();
        }

        public Guid CreateAttendanceMachine(AttendanceMachineCreationDTO attendanceMachineCreationDTO)
        {
            AttendanceMachine attendanceMachine = new AttendanceMachine(
                                                        attendanceMachineCreationDTO.AttendanceEvent,
                                                        true);
            context.AttendanceMachines.Add(attendanceMachine);
            context.SaveChanges();
            return attendanceMachine.Id;
        }
    }
}
