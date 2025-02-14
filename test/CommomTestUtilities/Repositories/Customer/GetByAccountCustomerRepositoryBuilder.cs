using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using Moq;

namespace CommomTestUtilities.Repositories.Customer;

public class GetByAccountCustomerRepositoryBuilder
{
    private readonly Mock<IGetByAccountCustomerRepository> _repository;
    public IGetByAccountCustomerRepository Build()
        => _repository.Object;

    public GetByAccountCustomerRepositoryBuilder()
    {
        _repository = new Mock<IGetByAccountCustomerRepository>();
    }

    public GetByAccountCustomerRepositoryBuilder GetByAccount(CustomerEntity entity)
    {
        _repository.Setup(rep => rep.GetByAccountAsync(entity.AccountNumber)).ReturnsAsync(entity);

        return this;
    }
}
