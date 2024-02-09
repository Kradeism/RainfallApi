using Newtonsoft.Json;

namespace RainfallApi.Models.Dtos
{
    public class ItemDto
    {
        public string? Measure { get; set; }
        public decimal Value { get; set; }
    }
}
