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
