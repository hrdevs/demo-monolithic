namespace demo_monolithic.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
