namespace RainfallApi.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            ErrorDetails = new List<ErrorDetails>();
        }

        public List<ErrorDetails>? ErrorDetails { get; }
    }
}
