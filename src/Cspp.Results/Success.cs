namespace Cspp.Results;

public readonly record struct Success : IResult;

public readonly record struct Success<T> : IResult<T>
{
    [Obsolete("Use Success<T>(T value) constructor instead.", true)]
    public Success() => throw new InvalidOperationException("None value provided.");

    public Success(T value)
    {
        this.Value = value;
    }

    public T Value { get; init; }
}