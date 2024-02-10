using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class SystemCodeDetail : UserActivity
    {
        public int Id { get; set; }
        public int SystemCodeId { get; set; }
        [MaxLength(50)]
        public SystemCode SystemCode { get; set; }
        public string Code { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public int? OrderNo { get; set; }
    }
    
}
