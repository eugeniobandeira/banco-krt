using BancoKrt.Domain.Entities;

namespace BancoKrt.Domain.Request.Transaction;

public class TransacionRequest
{
    public CustomerEntity Sender { get; set; }
    public decimal Amount { get; set; }
    public CustomerEntity Receiver { get; set; }
}
