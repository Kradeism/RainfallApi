namespace RainfallApi.Models
{
    public class ValidationResponse
    {
        public bool HasError { get; set; }
        public List<ErrorDetails>? Errors { get; set; }
    }
}
