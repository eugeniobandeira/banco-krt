namespace BancoKrt.Domain.Response.Customer;

public class CreatedCustomerResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string AgencyNumber { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public decimal TransactionLimit { get; set; }
    public decimal Balance { get; set; }
}
