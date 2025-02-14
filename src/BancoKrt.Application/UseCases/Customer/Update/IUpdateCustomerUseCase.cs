using BancoKrt.Domain.Request.Customer;
using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.Update;
public interface IUpdateCustomerUseCase
{
    Task<CreatedCustomerResponse> ExecuteAsync(string id, UpdateCustomerRequest req);
}
