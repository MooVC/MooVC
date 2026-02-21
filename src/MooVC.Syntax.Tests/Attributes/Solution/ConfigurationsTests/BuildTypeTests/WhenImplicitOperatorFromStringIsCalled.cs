namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "Custom";

        // Act
        Configurations.BuildType subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}