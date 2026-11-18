using static System.String;

namespace Cspp.Results;

public record Failure
{
    public static readonly Failure Unknown = new(
        Join(".", nameof(Failure), nameof(Unknown)),
        "Unknown failure.");

    public static readonly Failure Uninitialized = new(
        Join(".", nameof(Failure), nameof(Uninitialized)),
        "The result was not initialized with a value or a failure.");

    public Failure(string code, string error)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(error);

        Code = code;
        Error = error;
    }

    public string Code { get; init; }
    public string Error { get; init; }
}