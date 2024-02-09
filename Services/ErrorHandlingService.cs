using RainfallApi.Constants;
using RainfallApi.Enums;
using RainfallApi.Models;
using RainfallApi.Services.Interfaces;

namespace RainfallApi.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public ErrorDetails CreateErrorResponse(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.InvalidRequest => new ErrorDetails { Name = ErrorMessages.InvalidRequest },
                ErrorType.NoReadingsFound => new ErrorDetails { Name = ErrorMessages.NotFound },
                ErrorType.InternalServerError => new ErrorDetails { Name = ErrorMessages.InternalServer },
                _ => new ErrorDetails(),
            };
        }
    }
}
