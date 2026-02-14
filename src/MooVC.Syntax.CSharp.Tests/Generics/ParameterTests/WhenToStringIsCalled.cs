namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenToStringIsCalled
{
    private const string Name = "TValue";

    [Fact]
    public void GivenValueThenReturnsFormattedString()
    {
        // Arrange
        var constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var subject = new Parameter
        {
            Name = new Identifier(Name),
            Constraints = [constraint],
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Name);
    }
}