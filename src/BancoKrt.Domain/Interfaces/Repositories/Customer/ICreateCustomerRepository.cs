using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface ICreateCustomerRepository
{
    Task AddAsync(CustomerEntity entity);
}
