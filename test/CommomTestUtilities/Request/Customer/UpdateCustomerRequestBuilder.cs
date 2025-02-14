using BancoKrt.Domain.Request.Customer;
using Bogus;

namespace CommomTestUtilities.Request.Customer;

public class UpdateCustomerRequestBuilder
{
    public static UpdateCustomerRequest Build()
    {
        return new Faker<UpdateCustomerRequest>()
            .RuleFor(customer => customer.TransactionLimit, _ => 500);
    }
}
