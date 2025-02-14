using BancoKrt.Domain.Interfaces.Repositories.Customer;
using Moq;

namespace CommomTestUtilities.Repositories.Customer;

public class DeleteCustomerRepositoryBuilder
{
    private readonly Mock<IDeleteCustomerRepository> _repository;

    public DeleteCustomerRepositoryBuilder()
    {
        _repository = new Mock<IDeleteCustomerRepository>();
    }

    public DeleteCustomerRepositoryBuilder DoDelete(string id)
    {
        _repository.Setup(rep => rep.DeleteAsync(id)).Returns(Task.CompletedTask);

        return this;
    }

    public IDeleteCustomerRepository Build() 
        => _repository.Object;
    
}
