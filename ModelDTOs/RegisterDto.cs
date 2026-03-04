using System.ComponentModel.DataAnnotations;

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
        public string PasswordHash { get; set; } = null!;
    }
}
