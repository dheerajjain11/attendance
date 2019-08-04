using Domain;
using DTO;
using Persistence;
using System;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        public long CreateEmployee(string name)
        {
            Employee employee = new Employee(name);
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employeeContext.Add(employee);
                employeeContext.SaveChanges();
            }
            return employee.Id;
        }

        public void UpdateEmployee(long employeeId, EmployeeUpdateDTO updateDTO)
        {
            using(EmployeeContext employeeContext = new EmployeeContext())
            {
                Employee employee = employeeContext.Employees.Find(employeeId);
                employee.SetBuilding(updateDTO.BuildingName);
                employee.SetDesignation(updateDTO.Designation);
                employee.SetSeatNumber(updateDTO.SeatNumber);
                employeeContext.SaveChanges();
            }
        }

    }
}
