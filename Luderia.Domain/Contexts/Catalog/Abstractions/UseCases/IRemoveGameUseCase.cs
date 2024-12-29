namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public interface IRemoveGameUseCase
{
    Task<Result> Execute(int bggId);
}
