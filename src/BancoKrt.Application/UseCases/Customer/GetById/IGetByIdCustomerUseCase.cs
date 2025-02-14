using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.GetById;

public interface IGetByIdCustomerUseCase
{
    Task<CreatedCustomerResponse> ExecuteAsync(string id);
}
