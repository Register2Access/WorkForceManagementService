using WorkForceManagementService.Entities;
using WorkForceManagementService.ModelDTOs;

namespace WorkForceManagementService.Repositories.Interfaces
{
    public interface IAuthService
    {
        Task<int> Register(RegisterDto registerDto);
        Task<string> Login(string email, string password);
    }
}
