namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "ARM";

        // Act
        Configurations.Platform subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}