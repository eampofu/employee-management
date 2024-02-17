using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class Employee:UserActivity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Employee No")]
        public string EmpNo { get; set; }
        [MaxLength (100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(200)]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
            public int PhoneNumber { get; set; }
        [MaxLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [MaxLength(60)]
        public string Country { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(60)]
        public string Department { get; set; }
        [MaxLength(60)]
        public string Designation { get; set; }

    }
}
