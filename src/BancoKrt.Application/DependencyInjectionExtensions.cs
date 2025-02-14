using BancoKrt.Application.Mapping.Customer;
using BancoKrt.Application.UseCases.Customer.Delete;
using BancoKrt.Application.UseCases.Customer.GetAll;
using BancoKrt.Application.UseCases.Customer.GetByAccount;
using BancoKrt.Application.UseCases.Customer.GetById;
using BancoKrt.Application.UseCases.Customer.Register;
using BancoKrt.Application.UseCases.Customer.Update;
using BancoKrt.Application.UseCases.Transaction.Create;
using Microsoft.Extensions.DependencyInjection;

namespace BancoKrt.Application;

public static class DependencyInjectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    #region Services
    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
        services.AddScoped<IGetAllCustomerUseCase, GetAllCustomerUseCase>();
        services.AddScoped<IGetByIdCustomerUseCase, GetByIdCustomerUseCase>();
        services.AddScoped<IGetByAccountCustomerUseCase, GetByAccountCustomerUseCase>();
        services.AddScoped<IDeleteCustomerUseCase, DeleteCustomerUseCase>();

        services.AddScoped<ICreateTransactionUseCase, CreateTransactionUseCase>();
    }
    #endregion
}
