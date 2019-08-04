using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Employee: EntityBase
    {
        protected Employee()
        {
        }
        public string Name { get; protected set; }
        public string Designation { get; protected set; }
        public string SeatNumber { get; protected set; }
        public string BuildingName { get; protected set; }
        public Employee(string name)
        {
            this.Name = name;
        }
    }
}
