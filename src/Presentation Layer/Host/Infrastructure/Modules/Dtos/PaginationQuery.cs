namespace PresentationLayer.Host.Infrastructure.Modules.Dtos;

public record PaginationQuery(int Page = 1, int Size = 20, string? Sort = null);