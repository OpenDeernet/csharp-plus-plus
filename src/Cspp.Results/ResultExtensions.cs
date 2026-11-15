namespace Cspp.Results;

public static class ResultExtensions
{
    extension(Result result)
    {
        public bool IsSuccess => result.Value is Success;
        public bool IsFailure => !result.IsSuccess;

        public static Success<T> FromValue<T>(T value)
        {
            return new Success<T>(value);
        }

        public static Failure FromError(Error error)
        {
            return new Failure(error);
        }
    }

    extension<T>(Result<T> result)
    {
        public bool IsSuccess => result.Value is Success<T>;
        public bool IsFailure => !result.IsSuccess;
    }
}