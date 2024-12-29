namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public interface IAddTypeToGameUseCase
{
    Task<Result> Execute(int bggId, string name);
}