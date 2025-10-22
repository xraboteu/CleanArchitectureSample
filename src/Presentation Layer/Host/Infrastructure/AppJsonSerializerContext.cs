namespace PresentationLayer.Host.Infrastructure
{
    using PresentationLayer.Host.Infrastructure.Modules.Dtos;
    using System.Text.Json.Serialization;

    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(InvoiceDto))]
    [JsonSerializable(typeof(CreateProductDto))] 
    [JsonSerializable(typeof(CreateProductResponseDto))]
    public partial class AppJsonSerializerContext : JsonSerializerContext { }
}
