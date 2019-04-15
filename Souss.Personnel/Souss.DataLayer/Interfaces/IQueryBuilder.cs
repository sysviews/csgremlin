using Souss.Model;
using System.Collections.Generic;

namespace Souss.DataLayer
{
    public interface IQueryBuilder
    {
        (string Query, Dictionary<string, object> Parameters) BuildAddQuery(Person person);

        (string Query, Dictionary<string, object> Parameters) BuildGetQuery();

        (string Query, Dictionary<string, object> Parameters) BuildGetQuery(string id);

        (string Query, Dictionary<string, object> Parameters) BuildUpdateQuery(string id, Person person);

        (string Query, Dictionary<string, object> Parameters) BuildDeleteQuery(string id);

        (string Query, Dictionary<string, object> Parameters) BuildRelationshipQuery(string sourceId, string targetId);
    }
}
