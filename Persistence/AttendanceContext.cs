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
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceEvent> AttendanceEvents { get; set; }

        public AttendanceContext()
        {
        }

        public AttendanceContext(DbContextOptions<AttendanceContext> dbContextOptions):base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source =.\sqlexpress; initial catalog = MyMicroservices4; integrated security = True; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server = localhost; Database = master; User = sa; Password = Idk2wmpi");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
