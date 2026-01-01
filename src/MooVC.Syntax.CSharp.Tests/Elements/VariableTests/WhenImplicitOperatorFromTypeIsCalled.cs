namespace MooVC.Syntax.CSharp.Elements.VariableTests;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Variable> result = () => value!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenTypeThenVariableMatchesTypeName()
    {
        // Arrange
        Type value = typeof(Guid);

        // Act
        Variable subject = value;

        // Assert
        subject.ShouldBe(new Variable(nameof(Guid)));
    }
}