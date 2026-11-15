using JetBrains.Annotations;

namespace Cspp.Results.Tests;

[TestFixture]
[TestSubject(typeof(Result<>))]
public class ResultTTests
{
    [Test]
    public void ImplicitConversion_FromSuccess_ReturnsSuccessWithValue()
    {
        Result<int> result = new Success<int>(42);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsFailure, Is.False);
            Assert.That(result is Success<int>, Is.True);
            Assert.That(((Success<int>)result.Value).Value, Is.EqualTo(42));
        }
    }

    [Test]
    public void ImplicitConversion_FromFailure_ReturnsFailureWithError()
    {
        Result<int> result = new Failure(Error.Unknown);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result is Failure, Is.True);
            Assert.That(((Failure)result.Value!).Error, Is.EqualTo(Error.Unknown));
        }
    }
}