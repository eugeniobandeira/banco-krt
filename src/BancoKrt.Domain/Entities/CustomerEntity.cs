using Amazon.DynamoDBv2.DataModel;

namespace BancoKrt.Domain.Entities;

[DynamoDBTable("bankcustomers")]
public class CustomerEntity
{
    [DynamoDBHashKey] 
    public string Id { get; set; } = string.Empty;

    [DynamoDBProperty]
    public string Name { get; set; } = string.Empty;

    [DynamoDBProperty]
    public string Document { get; set; } = string.Empty;

    [DynamoDBProperty]
    public string AgencyNumber { get; set; } = string.Empty;

    [DynamoDBProperty]
    public string AccountNumber { get; set; } = string.Empty;

    [DynamoDBProperty]
    public decimal TransactionLimit { get; set; }

    [DynamoDBProperty]
    public decimal Balance { get; set; }
}
