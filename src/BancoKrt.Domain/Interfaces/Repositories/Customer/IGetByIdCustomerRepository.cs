using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface IGetByIdCustomerRepository
{
    Task<CustomerEntity> GetByIdAsync(string id);
}
