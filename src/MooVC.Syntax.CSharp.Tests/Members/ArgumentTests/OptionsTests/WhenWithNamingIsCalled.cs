namespace MooVC.Syntax.CSharp.Members.ArgumentTests.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithNamingIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Identifier.Options value = Identifier.Options.Pascal;

        // Act
        Argument.Options result = options.WithNaming(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Naming.ShouldBe(value);
        options.Naming.ShouldNotBe(value);
    }
}
