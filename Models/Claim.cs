using System;

namespace CMCS.Models
{
    public enum ClaimStatus
    {
        Pending,
        Verified,
        Approved,
        Rejected
    }

    public class Claim
    {
        public Guid Id { get; set; }
        public string LecturerName { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Notes { get; set; }
        public string DocumentName { get; set; }
        public ClaimStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
