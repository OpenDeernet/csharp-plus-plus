using JetBrains.Annotations;

namespace Cspp.Results.Tests;

[TestFixture]
[TestSubject(typeof(Success<>))]
public class SuccessTests
{
    [Test]
    [Obsolete("This is a test.")]
    public void Constructor_WithoutValue_ThrowsInvalidOperationException()
    {
        Assert.That(() => new Success<int>(), Throws.TypeOf<InvalidOperationException>());
    }
}