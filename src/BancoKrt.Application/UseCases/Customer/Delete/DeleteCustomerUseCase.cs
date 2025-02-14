using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;

namespace BancoKrt.Application.UseCases.Customer.Delete;

public class DeleteCustomerUseCase : IDeleteCustomerUseCase
{
    private readonly IGetByIdCustomerRepository _getByIdCustomerRepository;
    private readonly IDeleteCustomerRepository _deleteCustomerRepository;

    public DeleteCustomerUseCase(
        IGetByIdCustomerRepository getByIdCustomerRepository,
        IDeleteCustomerRepository deleteCustomerRepository)
    {
        _getByIdCustomerRepository = getByIdCustomerRepository;
        _deleteCustomerRepository = deleteCustomerRepository;
    }

    public async Task ExecuteAsync(string id)
    {
        var result = await _getByIdCustomerRepository.GetByIdAsync(id);

        if (result is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND);

        await _deleteCustomerRepository.DeleteAsync(id);
    }
}
