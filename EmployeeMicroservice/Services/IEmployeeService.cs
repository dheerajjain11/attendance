using DTO;

namespace Services
{
    public interface IEmployeeService
    {
        long CreateEmployee(string name);
        void UpdateEmployee(long employeeId, EmployeeUpdateDTO updateDTO);
    }
}