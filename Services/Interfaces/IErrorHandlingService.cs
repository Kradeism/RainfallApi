using RainfallApi.Enums;
using RainfallApi.Models;

namespace RainfallApi.Services.Interfaces
{
    public interface IErrorHandlingService
    {
        ErrorDetails CreateErrorResponse(ErrorType invalidRequest);
    }
}
