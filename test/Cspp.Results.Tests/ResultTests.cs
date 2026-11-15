using JetBrains.Annotations;

namespace Cspp.Results.Tests;

[TestFixture]
[TestSubject(typeof(Result))]
public class ResultTests
{
    [Test]
    public void ImplicitConversion_FromSuccess_ReturnsSuccessResult()
    {
        Result result = default(Success);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsFailure, Is.False);
            Assert.That(result is Success, Is.True);
        }
    }

    [Test]
    public void ImplicitConversion_FromFailure_ReturnsFailureResult()
    {
        Result result = new Failure(Error.Unknown);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result is Failure, Is.True);
        }
    }

    [Test]
    public void Success_WhenAccessed_IsSuccessResult()
    {
        Result result = Result.Success;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsFailure, Is.False);
            Assert.That(result is Success, Is.True);
        }
    }

    [Test]
    public void Failure_WhenAccessed_IsFailureWithUnknownError()
    {
        Result result = Result.Failure;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result is Failure, Is.True);
            Assert.That(((Failure)result.Value!).Error, Is.EqualTo(Error.Unknown));
        }
    }
}