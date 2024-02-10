using employee_management.Models;

namespace employee_management.Models
{
    public class UserActivity
    {
        public string?  CreatedById { get; set; }
        public DateTime CreatedOn { get; set; } = default(DateTime);
        public string? ModfiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

public class ApprovalActivity:UserActivity
{
    public string? ApprovedById { get; set; }
    public DateTime ApprovedOn { get; set; }
}