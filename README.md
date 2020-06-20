# dotnet-cqrs

This project shows a clean way to use CQRS without using the MediatR library.

In C# is common to use a library named [MediatR](https://github.com/jbogard/MediatR) to implement CQRS. This is an amazing library but forces you to implement the interface INotification, INotificationHandler<T> and IRequestHandler<T1,T2> in your domain/application layer coupling this with an infrastructure library.
This is a different approach to avoid add this coupling.

## Commands

### A command example

```csharp
public class CreateItemCommand : Command
{    
    public CreateItemCommand(Guid id, string name) 
    {
        Id = id;
        Name = name;
    }
}
```

### A handler example

```csharp
public class CreateItemCommandHandler : CommandHandler<CreateItemCommand>
{
    private readonly ItemRepository _repository;

    public CreateItemCommandHandler(ItemRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateItemCommand command)
    {
        await _repository.Add(new Item(command.Id, command.Name));
    }
}
```

### Interfaces to add in Domain Layer

[Command Interfaces](https://github.com/Leanwit/dotnet-cqrs/tree/master/Src/CQRS.Shared/Domain/Bus/Command)

## Queries

### A query example:

```csharp
public class FindItemQuery : Query
{
    public Guid Id { get; private set; }

    public FindItemQuery(Guid id)
    {
        Id = id;
    }
}
```

### A handler example

```csharp
public class FindItemQueryHandler : QueryHandler<FindItemQuery, ItemResponse>
{
    private readonly ItemRepository _repository;

    public FindItemQueryHandler(ItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ItemResponse> Handle(FindItemQuery query)
    {
        Item item = await _repository.GetById(query.Id);
        
        return new ItemResponse(item.Id, item.Name, item.IsCompleted);
    }
}
```

### Interfaces to add in Domain Layer

[Query Interfaces](https://github.com/Leanwit/dotnet-cqrs/tree/master/Src/CQRS.Shared/Domain/Bus/Query)

## InMemoryBus implementation

[InMemoryCommandBus](https://github.com/Leanwit/dotnet-cqrs/blob/master/Src/CQRS.Shared/Infrastructure/Bus/Command/InMemoryCommandBus.cs)

[InMemoryQueryBus](https://github.com/Leanwit/dotnet-cqrs/blob/master/Src/CQRS.Shared/Infrastructure/Bus/Query/InMemoryQueryBus.cs)

## Dependency Injection

### Command

```csharp
services.AddScoped<CommandHandler<CreateItemCommand>, CreateItemCommandHandler>();
```

### Query

```csharp
services.AddScoped<QueryHandler<FindItemQuery, ItemResponse>, FindItemQueryHandler>();
```

### Automatic Load

```csharp
services.AddCommandServices(typeof(Command).Assembly);
services.AddQueryServices(typeof(Query).Assembly);
```