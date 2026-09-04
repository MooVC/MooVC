namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenStringContainsName()
    {
        // Arrange
        Implementation subject = ImplementationTestsData.Create(name: (Qualification)"IComparable");

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains("IComparable");
    }
}