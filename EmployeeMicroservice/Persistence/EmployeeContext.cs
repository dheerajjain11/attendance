﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext()
        {
        }
        public EmployeeContext(DbContextOptions<EmployeeContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = master; User = sa; Password = Idk2wmpi");
            //optionsBuilder.UseSqlServer(@"Server = db; Database = master; User = sa;Password = Idk2wmpi; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server = localhost; Database = master; User = sa; Password = Idk2wmpi");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
