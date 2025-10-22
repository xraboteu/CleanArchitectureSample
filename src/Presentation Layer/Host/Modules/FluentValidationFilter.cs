using FluentValidation;

namespace PresentationLayer.Host.Modules
{
    public sealed class FluentValidationFilter<T> : IEndpointFilter
    {
        private readonly IValidator<T> _validator;

        public FluentValidationFilter(IValidator<T> validator) => _validator = validator;

        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext ctx, EndpointFilterDelegate next)
        {
            var model = ctx.Arguments.OfType<T>().FirstOrDefault();
            if (model is null)
                return Results.ValidationProblem(new Dictionary<string, string[]> { { "", new[] { "Payload manquant." } } });

            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid) return Results.ValidationProblem(result.ToDictionary());

            return await next(ctx);
        }
    }
}
