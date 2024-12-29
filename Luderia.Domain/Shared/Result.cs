public class Result<T>
{
    public T Value { get; }
    public Error? Error { get; }
    public bool IsSuccess => Error == null;
    public bool IsFailure => !IsSuccess;

    private Result(T value)
    {
        Value = value;
    }

    private Result(Error error)
    {
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(Error error) => new Result<T>(error);
    public static implicit operator Result<T>(Result result) => result.IsSuccess ? Success(default) : Failure(result.Error!);
}

public class Result
{
    public Error? Error { get; }
    public bool IsSuccess => Error == null;
    public bool IsFailure => !IsSuccess;

    private Result(Error error)
    {
        Error = error;
    }

    private Result() { }

    public static Result Success() => new Result();
    public static Result Failure(Error error) => new Result(error);

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);
}