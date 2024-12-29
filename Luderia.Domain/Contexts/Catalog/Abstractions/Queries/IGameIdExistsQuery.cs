namespace Luderia.Domain.Contexts.Catalog.Abstractions.Queries;

public interface IGameIdExistsQuery
{
    Task<bool> Execute(int id);
}