namespace WorkForceManagementService.Repositories.Interfaces
{
    public interface IAttendanceService
    {
        Task<string> PunchIn(int userId);
        Task<string> PunchOut(int userId);
    }
}
