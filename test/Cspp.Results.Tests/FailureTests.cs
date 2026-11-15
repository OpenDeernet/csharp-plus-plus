using JetBrains.Annotations;

namespace Cspp.Results.Tests;

[TestFixture]
[TestSubject(typeof(Failure))]
public class FailureTests
{
    [Test]
    [Obsolete("This is a test.")]
    public void Constructor_WithoutError_ThrowsInvalidOperationException()
    {
        Assert.That(() => new Failure(), Throws.TypeOf<InvalidOperationException>());
    }
}