namespace WorkForceManagementService.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }
        public Department Department { get; set; }
        public string? Designation { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    public enum UserRole
    {
        Admin = 1,
        Manager = 2,
        TeamLead = 3,
        Employee = 4
    }

    public enum Department
    {
        IT = 1,
        Management = 2,
        HROperations = 3,
        Finance = 4,
        TalentAcquisition = 5
    }
}
