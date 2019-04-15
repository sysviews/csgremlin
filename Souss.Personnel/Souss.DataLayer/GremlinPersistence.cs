using Gremlin.Net.Driver;
using System.Collections.Generic;

namespace Souss.DataLayer
{
    public class GremlinPersistence : IGremlinPersistence
    {
        private readonly IGremlinConnection _gremlinConnection;

        public GremlinPersistence(IGremlinConnection gremlinConnection)
        {
            _gremlinConnection = gremlinConnection;
        }

        public async System.Threading.Tasks.Task<IReadOnlyCollection<dynamic>> SubmitWithParametersAsync<TDynamic>(string query, Dictionary<string, object> parameters)
        {
            return await _gremlinConnection.Client.SubmitAsync<dynamic>(query, parameters);
        }
    }
}
