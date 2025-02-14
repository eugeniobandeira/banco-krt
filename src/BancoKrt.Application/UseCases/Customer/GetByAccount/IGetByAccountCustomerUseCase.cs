using BancoKrt.Domain.Response.Customer;

namespace BancoKrt.Application.UseCases.Customer.GetById;

public interface IGetByAccountCustomerUseCase
{
    Task<CreatedCustomerResponse> ExecuteAsync(string accountNumber);
}
