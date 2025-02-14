using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface IUpdateCustomerRepository
{
    Task UpdateAsync(CustomerEntity entity);
}
