namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("Custom");
    }
}