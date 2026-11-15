using System.Runtime.CompilerServices;

namespace Cspp.Results;

[Union]
public readonly record struct Result : IUnion
{
    public static readonly Success Success = default(Success);
    public static readonly Failure Failure = new(Error.Unknown);
    private readonly IResult result;

    public Result(Success success) => this.result = success;

    public Result(Failure failure) => this.result = failure;

    public object? Value => this.result;
}

[Union]
public readonly record struct Result<T> : IUnion
{
    private readonly IResult result;

    public Result(Success<T> success) => this.result = success;

    public Result(Failure failure) => this.result = failure;

    public object? Value => this.result;
}