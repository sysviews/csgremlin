using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;
using Souss.Model;

namespace Souss.DataLayer
{
    public class GremlinConnection : IGremlinConnection
    {
        public GremlinClient Client { get; internal set; }

        public GremlinConnection(IConfigurationProvider configurationProvider) => Client = new GremlinClient(
            new GremlinServer(
                configurationProvider.ConnectionEndpoint,
                configurationProvider.Port,
                true,
                configurationProvider.ConnectionDatabaseCollection,
                configurationProvider.ConnectionAuthKey),
            new GraphSON2Reader(),
            new GraphSON2Writer(),
            GremlinClient.GraphSON2MimeType);
    }
}
