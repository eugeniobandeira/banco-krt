using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BancoKrt.Domain.Interfaces.Repositories.Customer;
using BancoKrt.Domain.Interfaces.Repositories.Transaction;
using BancoKrt.Infrastructure.Repositories.Customer;
using BancoKrt.Infrastructure.Repositories.Transaction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoKrt.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDynamoDb(services, configuration);
        AddRepositories(services);
    }

    private static void AddDynamoDb(IServiceCollection services, IConfiguration configuration)
    {
        var awsSection = configuration.GetSection("AWS");
        var accessKey = awsSection["AccessKey"];
        var secretKey = awsSection["SecretKey"];

        if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("AWS credentials are not properly configured.");
        }

        var region = Amazon.RegionEndpoint.SAEast1;

        var credentials = new Amazon.Runtime.BasicAWSCredentials(accessKey, secretKey);
        var config = new AmazonDynamoDBConfig { RegionEndpoint = region };

        services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(credentials, config));
        services.AddScoped<IDynamoDBContext>(provider =>
        {
            var client = provider.GetRequiredService<IAmazonDynamoDB>();
            return new DynamoDBContext(client);
        });
    }


    private static void AddRepositories(IServiceCollection services)
    {
        #region Customer
        services.AddScoped<IDeleteCustomerRepository, CustomerRepository>();
        services.AddScoped<ICreateCustomerRepository, CustomerRepository>();
        services.AddScoped<IGetAllCustomerRepository, CustomerRepository>();
        services.AddScoped<IUpdateCustomerRepository, CustomerRepository>();
        services.AddScoped<IGetByAccountCustomerRepository, CustomerRepository>();
        services.AddScoped<IGetByIdCustomerRepository, CustomerRepository>();
        #endregion

        #region Transaction
        services.AddScoped<IUpdateTransactionRepository, TransactionRepository>();
        #endregion
    }
}
