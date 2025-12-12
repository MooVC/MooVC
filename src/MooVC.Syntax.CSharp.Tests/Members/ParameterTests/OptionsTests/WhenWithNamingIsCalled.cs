namespace MooVC.Syntax.CSharp.Members.ParameterTests.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNamingIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Parameter.Options();
        Identifier.Options value = Identifier.Options.Pascal;

        // Act
        Parameter.Options result = options.WithNaming(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Naming.ShouldBe(value);
        options.Naming.ShouldNotBe(value);
    }
}