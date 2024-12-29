namespace Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
public interface IGameTypeExistsQuery
{
    Task<bool> Execute(string type);
}
