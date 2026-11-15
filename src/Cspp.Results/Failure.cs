namespace Cspp.Results;

public readonly record struct Failure : IResult
{
    [Obsolete("Use Error(string code, string message) constructor instead.", true)]
    public Failure() => throw new InvalidOperationException("None error provided.");

    public Failure(Error error)
    {
        this.Error = error;
    }

    public Error Error { get; init; }
}