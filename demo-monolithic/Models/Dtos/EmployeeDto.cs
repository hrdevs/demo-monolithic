using System.ComponentModel.DataAnnotations;

namespace demo_monolithic.Models.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
