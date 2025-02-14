namespace BancoKrt.Application.UseCases.Customer.Delete;
public interface IDeleteCustomerUseCase
{
    Task ExecuteAsync(string id);
}
