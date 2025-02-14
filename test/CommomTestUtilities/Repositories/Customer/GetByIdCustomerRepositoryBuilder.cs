using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using Moq;

namespace CommomTestUtilities.Repositories.Customer;

public class GetByIdCustomerRepositoryBuilder
{
    private readonly Mock<IGetByIdCustomerRepository> _repository;
    public IGetByIdCustomerRepository Build()
        => _repository.Object;

    public GetByIdCustomerRepositoryBuilder()
    {
        _repository = new Mock<IGetByIdCustomerRepository>();
    }

    public GetByIdCustomerRepositoryBuilder GetByAccount(CustomerEntity entity)
    {
        _repository.Setup(rep => rep.GetByIdAsync(entity.Id)).ReturnsAsync(entity);

        return this;
    }
}
