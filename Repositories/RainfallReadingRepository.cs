using AutoMapper;
using RainfallApi.Models;
using RainfallApi.Repositories.Interfaces;
using RainfallApi.Services.Interfaces;

namespace RainfallApi.Repositories
{
    public class RainfallReadingRepository : IRainfallReadingRepository
    {
        private readonly IEnvironmentApiService _environmentApiService;
        private readonly IMapper _mapper;

        public RainfallReadingRepository(IEnvironmentApiService environmentApiService,
            IMapper mapper)
        {
            _environmentApiService = environmentApiService;
            _mapper = mapper;
        }

        public async Task<RainfallReading> GetRainfallReadingAsync(string stationId, int number, CancellationToken cancellationToken) 
        {          
            return _mapper.Map<RainfallReading>(await _environmentApiService.GetResourceAsync(stationId, number, cancellationToken));
        }
    }
}