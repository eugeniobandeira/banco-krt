namespace BancoKrt.Domain.Request.Customer;

public class CreateCustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string AgencyNumber { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public decimal TransactionLimit { get; set; }
    public decimal Balance { get; set; }
}
