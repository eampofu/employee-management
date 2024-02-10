using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class LeaveType:UserActivity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
