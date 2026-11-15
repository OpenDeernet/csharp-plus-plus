using JetBrains.Annotations;

namespace Cspp.Results.Tests;

[TestFixture]
[TestSubject(typeof(ResultExtensions))]
public class ResultExtensionsTests
{
    [Test]
    public void FromValue_WithValue_ReturnsSuccessWithValue()
    {
        Result<int> result = Result.FromValue(42);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsFailure, Is.False);
            Assert.That(result is Success<int>, Is.True);
            Assert.That(((Success<int>)result.Value).Value, Is.EqualTo(42));
        }
    }

    [Test]
    public void FromError_WithError_ReturnsFailureWithError()
    {
        Result<int> result = Result.FromError(Error.Unknown);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result is Failure, Is.True);
            Assert.That(((Failure)result.Value!).Error, Is.EqualTo(Error.Unknown));
        }
    }
}