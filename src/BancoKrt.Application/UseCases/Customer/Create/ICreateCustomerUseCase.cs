using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.Register;
public interface ICreateCustomerUseCase
{
    Task<CreatedCustomerResponse> ExecuteAsync(CreateCustomerRequest req);
}
