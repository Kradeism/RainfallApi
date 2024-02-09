using RainfallApi.Models.Dtos;

namespace RainfallApi.Services.Interfaces
{
    public interface IEnvironmentApiService
    {
        Task<RainfallReadingDto?> GetResourceAsync(string stationId, int number, CancellationToken cancellationToken);
    }
}
