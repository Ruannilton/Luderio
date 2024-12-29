namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public interface IRemoveGameTypeUseCase
{
    Task<Result> Execute(string name);
}
