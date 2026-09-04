namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenStringContainsName()
    {
        // Arrange
        Base subject = BaseTestsData.Create(name: (Qualification)"Comparable");

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains("Comparable");
    }
}