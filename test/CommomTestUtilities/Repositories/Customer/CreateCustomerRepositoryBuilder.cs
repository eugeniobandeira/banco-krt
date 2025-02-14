using BancoKrt.Domain.Interfaces.Repositories.Customer;
using Moq;

namespace CommomTestUtilities.Repositories.Customer;

public class CreateCustomerRepositoryBuilder
{
    public static ICreateCustomerRepository Build()
    {
        var mock = new Mock<ICreateCustomerRepository>();

        return mock.Object;
    }
}
