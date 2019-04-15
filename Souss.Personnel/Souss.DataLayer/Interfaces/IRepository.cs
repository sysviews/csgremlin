using Souss.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souss.DataLayer
{
    public interface IRepository
    {
        Task<Person> AddAsync(Person person);

        Task<IEnumerable<Person>> GetAsync();

        Task<Person> GetAsync(string id);

        Task UpdateAsync(string id, Person person);

        Task DeleteAsync(string id);

        Task RelateAsync(string sourceId, string targetId);
    }
}
