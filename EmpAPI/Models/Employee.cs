namespace EmployeeAPI
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeGender { get; set; } = string.Empty;
        public string EmployeeMobile { get; set; } = string.Empty;
        public string EmployeeDOB { get; set; } 
        public string ? Department { get; set; } = string.Empty;
        public string DateOfJoining { get; set; }
    }
}
