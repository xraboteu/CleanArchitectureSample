using FluentValidation;

namespace PresentationLayer.Billing.Application.Features.CreateInvoice
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0m);
        }
    }
}
