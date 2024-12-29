using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class SearchGameUseCase(ISearchGameQuery query) : ISearchGameUseCase
{
    public async Task<List<GameHeader>> Execute(SearchGameMessage criteria)
    {
        var games = await query.Execute(criteria);

        return games.ToList();
    }
}