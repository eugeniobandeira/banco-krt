using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using Moq;

namespace CommomTestUtilities.Repositories.Customer;

public class UpdateCustomerRepositoryBuilder
{
    public static IUpdateCustomerRepository Build(CustomerEntity entity)
    {
        var mock = new Mock<IUpdateCustomerRepository>();

        mock.Setup(rep => rep.UpdateAsync(entity)).Returns(Task.CompletedTask);

        return mock.Object;
    }
}
