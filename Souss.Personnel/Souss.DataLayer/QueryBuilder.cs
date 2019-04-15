using Souss.Model;
using System;
using System.Collections.Generic;

namespace Souss.DataLayer
{
    public class QueryBuilder : IQueryBuilder
    {
        public (string Query, Dictionary<string, object> Parameters) BuildAddQuery(Person person)
        {
            var query = $"g.addV('Person').property('id', id).property('FirstName', FirstName).property('LastName', LastName)";
            return (query, new Dictionary<string, object>
            {
                {"id", Guid.NewGuid().ToString() },
                {"FirstName", person.FirstName },
                {"LastName", person.LastName }
            });
        }

        public (string Query, Dictionary<string, object> Parameters) BuildGetQuery()
        {
            var query = $"g.V().has('label', 'Person')";
            return (query, null);
        }

        public (string Query, Dictionary<string, object> Parameters) BuildGetQuery(string id)
        {
            var query = $"g.V().has('label', 'Person').has('id', id)";
            return (query, new Dictionary<string, object>
            {
                {"id", id }
            });
        }

        public (string Query, Dictionary<string, object> Parameters) BuildUpdateQuery(string id, Person person)
        {
            var query = $"g.V(id).property('FirstName', FirstName).property('LastName', LastName)";
            return (query, new Dictionary<string, object>
            {
                {"id", id },
                {"FirstName", person.FirstName },
                {"LastName", person.LastName }
            });
        }

        public (string Query, Dictionary<string, object> Parameters) BuildDeleteQuery(string id)
        {
            var query = $"g.V(id).has('label', 'Person').drop()";
            return (query, new Dictionary<string, object>
            {
                { "id", id }
            });
        }

        public (string Query, Dictionary<string, object> Parameters) BuildRelationshipQuery(string sourceId, string targetId)
        {
            var query = "g.V(sourceId).addE(relationship).to(g.V(targetId))";
            return (query, new Dictionary<string, object>
            {
                {"sourceId", sourceId },
                {"relationship", "knows" },
                {"targetId", targetId }
            });
        }
    }
}
