using Amazon.DynamoDBv2.DataModel;
using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Transaction;

namespace BancoKrt.Infrastructure.Repositories.Transaction;

public class TransactionRepository : IUpdateTransactionRepository
{
    private readonly IDynamoDBContext _context;

    public TransactionRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task RegisterTransaction(CustomerEntity sender, CustomerEntity receiver)
    {
        await Task.WhenAll(
            _context.SaveAsync(sender),
            _context.SaveAsync(receiver)
        );
    }
}
