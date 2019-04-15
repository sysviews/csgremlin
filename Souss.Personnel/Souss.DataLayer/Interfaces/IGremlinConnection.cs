using Gremlin.Net.Driver;

namespace Souss.DataLayer
{
    public interface IGremlinConnection
    {
        GremlinClient Client { get; }
    }
}
