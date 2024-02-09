using RainfallApi.Models;

namespace RainfallApi.Services.Interfaces
{
    public interface IRainfallReadingService
    {
        Task<RainfallReading> ExecuteAsync(string id, int number, CancellationToken cancellationToken);
    }
}
