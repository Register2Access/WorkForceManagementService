using System.ComponentModel.DataAnnotations;

namespace WorkForceManagementService.ModelDTOs
{
    public class PunchInTimeRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime PunchInTime { get; set; }

    }
}
