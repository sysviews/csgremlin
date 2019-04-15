namespace Souss.Model
{
    public interface IConfigurationProvider
    {
        string ConnectionEndpoint { get; }

        int Port { get; }

        string ConnectionDatabaseCollection { get; }

        string ConnectionAuthKey { get; }
    }
}
