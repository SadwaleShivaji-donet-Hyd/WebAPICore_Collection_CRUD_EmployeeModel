using System.ComponentModel.DataAnnotations;
namespace WebAPICore_Collection_CRUD_EmployeeModel.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name Should be Between 3 to 30 letter")]
        public string Name { get; set; }
        public string? Department { get; set; }


        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]

        public string MobileNo { get; set; }


        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
