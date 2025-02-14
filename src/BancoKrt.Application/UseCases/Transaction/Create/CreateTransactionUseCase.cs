using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Interfaces.Repositories.Transaction;
using BancoKrt.Exception.ExceptionBase;
using BancoKrt.Exception.MessageResource;

namespace BancoKrt.Application.UseCases.Transaction.Create;

public class CreateTransactionUseCase : ICreateTransactionUseCase
{
    private readonly IGetByAccountCustomerRepository _getByAccountCustomerRepository;
    private readonly IUpdateTransactionRepository _updateTransactionRepository;

    public CreateTransactionUseCase(
        IGetByAccountCustomerRepository getByAccountCustomerRepository,
        IUpdateTransactionRepository updateTransactionRepository)
    {
        _getByAccountCustomerRepository = getByAccountCustomerRepository;
        _updateTransactionRepository = updateTransactionRepository;
    }

    public async Task ExecuteAsync(CustomerEntity sender, decimal amount, CustomerEntity receiver)
    {
        Validate(sender, amount, receiver);
        bool receiverExists = await SearchReceiver(receiver, _getByAccountCustomerRepository);

        if (receiverExists)
            ProcessTransfer(sender, amount, receiver);

        await UpdateBalance(sender, receiver, _updateTransactionRepository);
    }

    private static void Validate(CustomerEntity sender, decimal amount, CustomerEntity receiver)
    {
        if (sender == null) throw new ArgumentNullException(nameof(sender));
        if (receiver == null) throw new ArgumentNullException(nameof(receiver));
        if (amount <= 0) throw new ArgumentException(ErrorMessageResource.AMOUNT_GREATER_THAN_ZERO, nameof(amount));

        IsBalanceAvailable(sender, amount);
        IsAmountAllowed(sender, amount);
    }

    private static async Task<bool> SearchReceiver(CustomerEntity entity, IGetByAccountCustomerRepository repository)
    {
        var receiver = await repository.GetByAccountAsync(entity.AccountNumber);

        if (receiver is null)
            throw new NotFoundException(ErrorMessageResource.NOT_FOUND);

        return true;
    }

    private static void IsBalanceAvailable(CustomerEntity sender, decimal amount)
    {
        if (sender.Balance < amount)
            throw new BadRequestException(ErrorMessageResource.INSUFFICIENT_FOUNDS);
    }

    private static void IsAmountAllowed(CustomerEntity sender, decimal amount)
    {
        if (sender.TransactionLimit < amount)
            throw new BadRequestException(ErrorMessageResource.TRANSACTION_AMOUNT_NOT_ALLOWED);
    }

    private static void ProcessTransfer(CustomerEntity sender, decimal amount, CustomerEntity receiver)
    {
        sender.Balance -= amount;
        receiver.Balance += amount;
    }

    private static async Task UpdateBalance(CustomerEntity sender, CustomerEntity receiver, IUpdateTransactionRepository repository)
    {
        await repository.RegisterTransaction(sender, receiver);
    }
}
