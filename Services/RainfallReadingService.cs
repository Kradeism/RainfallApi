using RainfallApi.Models;
using RainfallApi.Repositories.Interfaces;
using RainfallApi.Services.Interfaces;

namespace RainfallApi.Services
{
    public class RainfallReadingService : IRainfallReadingService
    {
        private readonly IRainfallReadingRepository _rainfallReadingRepository;

        public RainfallReadingService(IRainfallReadingRepository rainfallReadingRepository)
        {
            _rainfallReadingRepository = rainfallReadingRepository;
        }


        public async Task<RainfallReading> ExecuteAsync(string id, int number, CancellationToken cancellationToken)
        {
            return await _rainfallReadingRepository.GetRainfallReadingAsync(id, number, cancellationToken);
        }
    }
}
