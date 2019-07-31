using DTO;
using Persistence;
using System;
using Domain;

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

            if(attendanceMachine!=null)
            {
                Attendance attendance = new Attendance(attendanceMachine);
                attendance.Mark(attendanceDTO.PersonId, attendanceDTO.AttendanceEntry, DateTime.Now);
                context.Attendances.Add(attendance);
                context.SaveChanges();
            }
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
    }
}
