using BancoKrt.Domain.Request.Customer;
using Bogus;
using Bogus.Extensions.Brazil;

namespace CommomTestUtilities.Request.Customer;

public class CreateCustomerRequestBuilder
{
    public static CreateCustomerRequest Build()
    {
        return new Faker<CreateCustomerRequest>()
            .RuleFor(customer => customer.Name, fk => fk.Person.FullName)
            .RuleFor(customer => customer.Document, fk => fk.Person.Cpf())
            .RuleFor(customer => customer.AgencyNumber, fk => fk.Random.UInt(1000, 9999).ToString())
            .RuleFor(customer => customer.AccountNumber, fk => fk.Random.UInt(10000, 99999).ToString())
            .RuleFor(customer => customer.Balance, _ => 1500)
            .RuleFor(customer => customer.TransactionLimit, _ => 500);
    }
}
