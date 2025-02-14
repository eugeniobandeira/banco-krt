using BancoKrt.Domain.Entities;

namespace BancoKrt.Application.UseCases.Transaction.Create;
public interface ICreateTransactionUseCase
{
    Task ExecuteAsync(CustomerEntity sender, decimal amount, CustomerEntity receiver);
}
