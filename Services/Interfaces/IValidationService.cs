using RainfallApi.Models;

namespace RainfallApi.Services.Interfaces
{
    public interface IValidationService
    {
        ValidationResponse ValidateInput(string stationId, int number);
    }
}
