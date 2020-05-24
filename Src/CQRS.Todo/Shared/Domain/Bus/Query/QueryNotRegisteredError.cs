using System;

namespace CQRS.Todo.Shared.Domain.Bus
{
    public class QueryNotRegisteredError : Exception
    {
        public QueryNotRegisteredError(Query query) : base(
            $"The query {query} has not a query handler associated")
        {
        }
    }
}