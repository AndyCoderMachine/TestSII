namespace TestSII.Models
{

    public class EmployeeApiResponse
    {
        public string Status { get; set; }
        public EmployeeData Data { get; set; }
        public string Message { get; set; }
    }

    public class EmployeeData
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int Age { get; set; }
        public string Dob { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
    }
}
