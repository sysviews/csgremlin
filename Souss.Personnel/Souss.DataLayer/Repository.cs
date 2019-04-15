using Souss.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souss.DataLayer
{
    public class Repository : IRepository
    {
        private readonly IGremlinPersistence _gremlinPersistence;
        private readonly IQueryBuilder _queryBuilder;
        private readonly IModelParser _modelParser;

        public Repository(IGremlinPersistence gremlinPersistence, IQueryBuilder queryBuilder, IModelParser modelParser)
        {
            _gremlinPersistence = gremlinPersistence;
            _queryBuilder = queryBuilder;
            _modelParser = modelParser;
        }

        public async Task<Person> AddAsync(Person person)
        {
            var query = _queryBuilder.BuildAddQuery(person);
            var result = await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);

            return _modelParser.ParseResultSet(result).FirstOrDefault();
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            var query = _queryBuilder.BuildGetQuery();
            var result = await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);

            return _modelParser.ParseResultSet(result);
        }

        public async Task<Person> GetAsync(string id)
        {
            var query = _queryBuilder.BuildGetQuery(id);
            var result = await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);

            return _modelParser.ParseResultSet(result).FirstOrDefault();
        }

        public async Task UpdateAsync(string id, Person person)
        {
            var query = _queryBuilder.BuildUpdateQuery(id, person);
            await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);
        }

        public async Task DeleteAsync(string id)
        {
            var query = _queryBuilder.BuildDeleteQuery(id);
            await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);
        }

        public async Task RelateAsync(string sourceId, string targetId)
        {
            var query = _queryBuilder.BuildRelationshipQuery(sourceId, targetId);
            await _gremlinPersistence.SubmitWithParametersAsync<dynamic>(query.Query, query.Parameters);
        }
    }
}
