using Amazon.DynamoDBv2;
using Amazon.Runtime;

namespace BancoKrt.Infrastructure.Database;

public static class DynamoDbClientFactory
{
    public static AmazonDynamoDBClient CreateClient(string accessKey, string secretKey, string region)
    {
        var credentials = new BasicAWSCredentials(accessKey, secretKey);

        var config = new AmazonDynamoDBConfig()
        {
            RegionEndpoint = Amazon.RegionEndpoint.SAEast1
        };

        return new AmazonDynamoDBClient(credentials, config);
    }
}
