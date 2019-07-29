using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class AttendanceContext : DbContext
    {
        public DbSet<AttendanceItem> AttendanceItems { get; set; }
        public DbSet<AttendanceMachine> AttendanceMachines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = master; User = sa; Password = Idk2wmpi");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
