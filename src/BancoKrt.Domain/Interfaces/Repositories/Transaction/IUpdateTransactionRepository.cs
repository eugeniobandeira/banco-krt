using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Interfaces.Repositories.Transaction;

public interface IUpdateTransactionRepository
{
    Task RegisterTransaction(CustomerEntity sender, CustomerEntity receiver);
}
