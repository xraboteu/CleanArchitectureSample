namespace PresentationLayer.Host.Infrastructure
{
    using PresentationLayer.Host.Infrastructure.Modules;
    using System.Text.Json.Serialization;

    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(InvoiceDto))]
    public partial class AppJsonSerializerContext : JsonSerializerContext { }
}
