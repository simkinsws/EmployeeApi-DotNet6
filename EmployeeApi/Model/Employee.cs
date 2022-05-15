namespace EmployeeApi.Model
{
    public class Employee
    {
        
        public string Id { get; set; }
        //public string tz { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty; // check either the string is null or "".
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double Salary { get; set; }
    }
}
