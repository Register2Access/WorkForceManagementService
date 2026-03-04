using System.ComponentModel.DataAnnotations;
using WorkForceManagementService.Entities;

namespace WorkForceManagementService.ModelDTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [MaxLength(15, ErrorMessage = "Password cannot exceed 15 characters")]
        public string PasswordHash { get; set; } = null!;
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = null!;
    }
}
