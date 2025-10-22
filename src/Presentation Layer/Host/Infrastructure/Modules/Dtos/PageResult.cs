namespace PresentationLayer.Host.Infrastructure.Modules.Dtos;

public record PageResult<T>(IReadOnlyList<T> Items, int Page, int Size, int Total);