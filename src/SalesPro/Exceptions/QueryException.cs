using System.Runtime.Serialization;
using Microsoft.AspNetCore.WebUtilities;

namespace SalesPro.Exceptions
{
    [Serializable]
    public class QueryException : Exception
    {
        public QueryException(string failedCommand, string errorDescription)
        {
            FailedCommands.Add(new KeyValuePair<string, string>(failedCommand, errorDescription));
        }

        public QueryException(IEnumerable<QueryException> innerExceptions)
        {
            FailedCommands = innerExceptions.SelectMany(e => e.FailedCommands).ToList();
        }

        protected QueryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public List<KeyValuePair<string, string>> FailedCommands { get; init; } = new List<KeyValuePair<string, string>>();
    }
}