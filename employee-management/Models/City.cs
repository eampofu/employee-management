using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class City:UserActivity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } 
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
