using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public class RemoveGameTypeUseCase : IRemoveGameTypeUseCase
{
    private readonly IGameTypeRepository _gameTypeRepository;

    public RemoveGameTypeUseCase(IGameTypeRepository gameTypeRepository)
    {
        _gameTypeRepository = gameTypeRepository;
    }

    public async Task<Result> Execute(string name)
    {
        _gameTypeRepository.RemoveType(name);
        return Result.Success();
    }
}

