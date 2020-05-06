using System;
using CQRS.Shared.Domain.Bus.Query;

namespace CQRS.Todo.Items.Application.Find
{
    public class FindItemQuery : Query
    {
        public Guid Id { get; private set; }

        public FindItemQuery(Guid id)
        {
            Id = id;
        }
    }
}