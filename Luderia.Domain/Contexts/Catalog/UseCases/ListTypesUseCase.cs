using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;
internal class ListTypesUseCase : IListTypesUseCase
{
    private readonly IListGameTypesQuery listGameTypesQuery;

    public ListTypesUseCase(IListGameTypesQuery listGameTypesQuery)
    {
        this.listGameTypesQuery = listGameTypesQuery;
    }
    public async Task<List<GameType>> Execute()
    {
        var types = await listGameTypesQuery.Execute();

        return types;
    }
}
