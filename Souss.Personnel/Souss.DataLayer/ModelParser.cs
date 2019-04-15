using Souss.Model;
using System.Collections.Generic;
using System.Linq;

namespace Souss.DataLayer
{
    public class ModelParser : IModelParser
    {
        public IEnumerable<Person> ParseResultSet(IReadOnlyCollection<dynamic> vertices)
        {
            var persons = new List<Person>();
            if (vertices == null || vertices.Count == 0) return persons;

            persons.AddRange(vertices.Select(kvp => ParsePerson(kvp)).Select(x => (Person)x));
            return persons;
        }

        private Person ParsePerson(IReadOnlyDictionary<string, object> keyValuePair)
        {
            var person = new Person { id = keyValuePair["id"].ToString() };

            var properties = keyValuePair["properties"] as Dictionary<string, object>;
            person.FirstName = GetValueFromDictionary(nameof(person.FirstName), properties);
            person.LastName = GetValueFromDictionary(nameof(person.LastName), properties);
            return person;
        }

        private string GetValueFromDictionary(string key, IReadOnlyDictionary<string, object> propertyBag)
        {
            if (propertyBag.ContainsKey(key))
            {
                var myvalues = (propertyBag[key] as IEnumerable<object>).ToList().FirstOrDefault();

                if (myvalues == null)
                {
                    return string.Empty;
                }

                foreach (var v in (Dictionary<string, object>)myvalues)
                {
                    if (v.Key.ToUpper().Equals("VALUE"))
                    {
                        return v.Value.ToString();
                    }
                }
            }

            return string.Empty;
        }
    }
}
