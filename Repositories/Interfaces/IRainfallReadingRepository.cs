using RainfallApi.Models;

namespace RainfallApi.Repositories.Interfaces
{
    public interface IRainfallReadingRepository
    {
        Task<RainfallReading> GetRainfallReadingAsync(string stationId, int number, CancellationToken cancellationToken);
    }
}
