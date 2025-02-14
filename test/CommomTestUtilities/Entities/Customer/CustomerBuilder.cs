using BancoKrt.Domain.Entities;
using Bogus;
using Bogus.Extensions.Brazil;

namespace CommomTestUtilities.Entities.Customer;

public class CustomerBuilder
{
    public static CustomerEntity Build()
    {
        return new Faker<CustomerEntity>()
            .RuleFor(customer => customer.Id, _ => "123456")
            .RuleFor(customer => customer.Name, fk => fk.Person.FullName)
            .RuleFor(customer => customer.Document, fk => fk.Person.Cpf())
            .RuleFor(customer => customer.AgencyNumber, fk => fk.Random.UInt(1000, 9999).ToString())
            .RuleFor(customer => customer.AccountNumber, fk => fk.Random.UInt(10000, 99999).ToString())
            .RuleFor(customer => customer.Balance, _ => 1500)
            .RuleFor(customer => customer.TransactionLimit, _ => 500);
    }
}
