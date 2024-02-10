namespace employee_management.Models
{
    public class LeaveApplication:ApprovalActivity
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int NoOfDays { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationId { get; set; }
        public SystemCodeDetail Duration { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType Leavetype { get; set; }
        public string? Attachment { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }



    }
}
