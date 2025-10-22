using FluentValidation;

namespace PresentationLayer.Host.Infrastructure.Modules
{
    public sealed class FluentValidationFilter<T> : IEndpointFilter
    {
        private readonly IValidator<T> _validator;

        public FluentValidationFilter(IValidator<T> validator) => _validator = validator;

        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext ctx, EndpointFilterDelegate next)
        {
            var model = ctx.Arguments.FirstOrDefault();
            if (model is null)
                return Results.ValidationProblem(new Dictionary<string, string[]> { { "", new[] { "Payload manquant." } } });

            if (model is not T typedModel)
                return Results.ValidationProblem(new Dictionary<string, string[]> { { "", new[] { "Type du payload invalide." } } });

            var validationContext = new FluentValidation.ValidationContext<T>(typedModel);
            var result = await _validator.ValidateAsync(validationContext);
            if (!result.IsValid) return Results.ValidationProblem(result.ToDictionary());

            return await next(ctx);
        }
    }
}
