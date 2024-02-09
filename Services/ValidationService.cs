using RainfallApi.Constants;
using RainfallApi.Models;
using RainfallApi.Services.Interfaces;

namespace RainfallApi.Services
{
    public class ValidationService : IValidationService
    {
        private const int MIN_NUM_STATION = 0;

        public ValidationResponse ValidateInput(string stationId, int number) 
        {
            var response = new ValidationResponse();
            var errors = new List<ErrorDetails>();

            if (string.IsNullOrEmpty(stationId)) 
            {
                errors.Add(new ErrorDetails() 
                {
                    Name = ErrorMessages.InvalidRequest,
                    Message = nameof(stationId)
                });

                response.HasError = true;
            }

            if (number <= MIN_NUM_STATION) 
            {
                errors.Add(new ErrorDetails()
                {
                    Name = ErrorMessages.InvalidRequest,
                    Message = nameof(number)
                });

                response.HasError = true;
            }

            response.Errors = errors;

            return response;
        }
    }
}
