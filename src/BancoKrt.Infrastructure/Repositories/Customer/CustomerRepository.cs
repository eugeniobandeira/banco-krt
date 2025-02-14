using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BancoKrt.Domain.Entities;
using BancoKrt.Domain.Interfaces.Repositories.Customer;

namespace BancoKrt.Infrastructure.Repositories.Customer;

public class CustomerRepository : 
    ICreateCustomerRepository,
    IDeleteCustomerRepository,
    IGetAllCustomerRepository,
    IGetByIdCustomerRepository,
    IGetByAccountCustomerRepository, 
    IUpdateCustomerRepository
{
    private readonly IDynamoDBContext _context;

    public CustomerRepository(IAmazonDynamoDB amazonDynamoDb)
    {
        _context = new DynamoDBContext(amazonDynamoDb);
    }
    public async Task AddAsync(CustomerEntity entity)
    {
        await _context.SaveAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.DeleteAsync<CustomerEntity>(id);
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var response = _context.ScanAsync<CustomerEntity>(null);
        return await response.GetNextSetAsync();
    }

    public async Task<CustomerEntity> GetByAccountAsync(string accountNumber)
    {
        return await _context.LoadAsync<CustomerEntity>(accountNumber);
    }

    public async Task<CustomerEntity> GetByIdAsync(string id)
    {
        return await _context.LoadAsync<CustomerEntity>(id);
    }

    public async Task UpdateAsync(CustomerEntity entity)
    {
        await _context.SaveAsync(entity);
    }
}
