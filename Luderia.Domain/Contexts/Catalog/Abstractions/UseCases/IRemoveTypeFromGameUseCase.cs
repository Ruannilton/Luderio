public interface IRemoveTypeFromGameUseCase
{
    Task<Result> Execute(int bggId, string name);
}