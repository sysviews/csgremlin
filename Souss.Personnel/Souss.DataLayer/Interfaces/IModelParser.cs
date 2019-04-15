using Souss.Model;
using System.Collections.Generic;

namespace Souss.DataLayer
{
    public interface IModelParser
    {
        IEnumerable<Person> ParseResultSet(IReadOnlyCollection<dynamic> vertices);
    }
}
