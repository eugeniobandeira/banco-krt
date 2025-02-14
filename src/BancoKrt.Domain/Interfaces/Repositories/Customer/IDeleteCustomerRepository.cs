namespace BancoKrt.Domain.Interfaces.Repositories.Customer;
public interface IDeleteCustomerRepository
{
    Task DeleteAsync(string id);
}
