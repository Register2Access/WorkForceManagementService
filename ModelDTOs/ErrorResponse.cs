namespace WorkForceManagementService.ModelDTOs
{
    public class ErrorResponse
    {
        public List<Error>? Errors { get; set; }
    }

    public class Error
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}
