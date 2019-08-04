using Domain.Base;

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
        
        public void SetDesignation(string designation)
        {
            this.Designation = designation;
            //raise event designation changed
        }

        public void SetSeatNumber(string seatNumber)
        {
            this.SeatNumber = seatNumber;
            //raise event seatchanged
        }

        public void SetBuilding(string building)
        {
            this.BuildingName = building;
            //raise event Building changed
        }
    }
}
