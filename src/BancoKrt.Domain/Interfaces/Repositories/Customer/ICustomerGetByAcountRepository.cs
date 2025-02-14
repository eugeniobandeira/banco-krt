using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface IGetByAccountCustomerRepository
{
    Task<CustomerEntity> GetByAccountAsync(string accountNumber);
}
