namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public interface IAddGameTypeUseCase
{
    Task<Result> Execute(string type);
}
