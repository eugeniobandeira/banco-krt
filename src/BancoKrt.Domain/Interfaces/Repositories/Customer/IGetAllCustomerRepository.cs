using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface IGetAllCustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
}
