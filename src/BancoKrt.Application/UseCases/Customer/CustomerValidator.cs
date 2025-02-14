using BancoKrt.Domain.Request.Customer;
using BancoKrt.Exception.MessageResource;
using FluentValidation;

namespace BancoKrt.Application.UseCases.Customer;

public class CustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.NAME_REQUIRED);

        RuleFor(customer => customer.Document)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.DOCUMENT_REQUIRED);

        RuleFor(customer => customer.AgencyNumber)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.AGENCY_NUMBER_REQUIRED);

        RuleFor(customer => customer.AccountNumber)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.ACCOUNT_NUMBER_REQUIRED);

        RuleFor(customer => customer.TransactionLimit)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.TRANSACTION_LIMIT_REQUIRED);

        RuleFor(customer => customer.Balance)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.BALANCE_REQUIRED);
    }
}
