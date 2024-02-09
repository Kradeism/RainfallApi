using RainfallApi.Models;

namespace RainfallApi.Services.Interfaces
{
    public interface IRainfallReadingService
    {
        Task<RainfallReading> GetRainfallReadingAsync(string id, int number, CancellationToken cancellationToken);
    }
}
