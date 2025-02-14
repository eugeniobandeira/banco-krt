using BancoKrt.Domain.Request.Transaction;
using Bogus;
using CommomTestUtilities.Entities.Customer;

namespace CommomTestUtilities.Request.Transaction;

public class TransactionRequestBuilder
{
    public static TransactionRequest Build()
    {
        return new Faker<TransactionRequest>()
            .RuleFor(customer => customer.Sender, _ => CustomerBuilder.Build())
            .RuleFor(customer => customer.Receiver, _ => CustomerBuilder.Build())
            .RuleFor(customer => customer.Amount, _ => 500);
    }
}
