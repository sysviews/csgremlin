using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souss.DataLayer
{
    public interface IGremlinPersistence
    {
        Task<IReadOnlyCollection<dynamic>> SubmitWithParametersAsync<TDynamic>(string query, Dictionary<string, object> parameters);
    }
}
