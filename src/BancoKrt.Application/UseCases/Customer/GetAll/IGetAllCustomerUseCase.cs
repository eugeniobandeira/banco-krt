using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.GetAll;
public interface IGetAllCustomerUseCase
{
    Task<CustomerResponseList> ExecuteAsync();
}
