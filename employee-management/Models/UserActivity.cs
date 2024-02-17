using employee_management.Models;
using System.ComponentModel.DataAnnotations;

namespace employee_management.Models
{
    public class UserActivity
    {
        [Display(Name = "Created By")]
        public string?  CreatedById { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = default(DateTime);
        [Display(Name = "Modified By")]
        public string? ModfiedById { get; set; }
        [Display(Name = "Modified on")]
        public DateTime ModifiedOn { get; set; }
    }
}

public class ApprovalActivity:UserActivity
{
    [Display(Name ="Approved By")]
    public string? ApprovedById { get; set; }
    [Display(Name = "Approved On")]
    public DateTime ApprovedOn { get; set; }
}