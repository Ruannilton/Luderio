using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public class AddGameTypeUseCase : IAddGameTypeUseCase
{
    private readonly IGameTypeRepository _gameTypeRepository;
    private readonly IGameTypeExistsQuery _gameTypeExistsQuery;

    public AddGameTypeUseCase(IGameTypeRepository gameTypeRepository, IGameTypeExistsQuery gameTypeExistsQuery)
    {
        _gameTypeRepository = gameTypeRepository;
        _gameTypeExistsQuery = gameTypeExistsQuery;
    }

    public async Task<Result> Execute(string type)
    {
        if (await _gameTypeExistsQuery.Execute(type))
            return Result.Failure(new GameTypeAlreadyExistsError());

        _gameTypeRepository.AddType(type);

        return Result.Success();
    }
}

