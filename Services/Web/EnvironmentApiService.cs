using Newtonsoft.Json;
using RainfallApi.Constants;
using RainfallApi.Models.Dtos;
using RainfallApi.Services.Interfaces;

namespace RainfallApi.Services.Web
{
    public class EnvironmentApiService : IEnvironmentApiService
    {
        private readonly HttpClient _httpClient;

        public EnvironmentApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationConstants.EnvironmentApiBaseUrl);
        }

        public async Task<RainfallReadingDto?> GetResourceAsync(string stationId, int number, CancellationToken cancellationToken)
        {
            var resourcePath = string.Format(ConfigurationConstants.RainfallMeasureUrl, stationId, number);
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(resourcePath);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync(cancellationToken);

                    return JsonConvert.DeserializeObject<RainfallReadingDto>(json);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch resource: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
