using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class Employee:UserActivity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string EmpNo { get; set; }
        [MaxLength (100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
            public int PhoneNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [MaxLength(60)]
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(60)]
        public string Department { get; set; }
        [MaxLength(60)]
        public string Designation { get; set; }

    }
}
