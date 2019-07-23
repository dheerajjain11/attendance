using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class AttendanceMachineRepository
    {
        private AttendanceContext attendanceContext;
        public AttendanceMachineRepository(AttendanceContext attendanceContext)
        {
            this.attendanceContext = attendanceContext;

        }

        public void AddAttendanceMachine(AttendanceMachine machine)
        {
            attendanceContext.AttendanceMachines.Add(machine);
            attendanceContext.SaveChanges();
        }
    }
}
