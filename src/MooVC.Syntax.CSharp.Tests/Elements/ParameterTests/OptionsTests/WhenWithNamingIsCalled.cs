namespace MooVC.Syntax.CSharp.Elements.ParameterTests.OptionsTests;

public sealed class WhenWithNamingIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Parameter.Options();
        Variable.Options value = Variable.Options.Pascal;

        // Act
        Parameter.Options result = options.WithNaming(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Naming.ShouldBe(value);
        options.Naming.ShouldNotBe(value);
    }
}