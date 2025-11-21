namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenToStringIsCalled
{
    private const string Name = "TValue";

    [Fact]
    public void GivenValueThenReturnsFormattedString()
    {
        // Arrange
        Constraint constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        var subject = new Parameter
        {
            Name = new Identifier(Name),
            Constraints = ImmutableArray.Create(constraint),
        };

        // Act
        string result = subject.ToString();

        // Assert
        string expected = string.Format(
            "Parameter {{ Name = {0}, Constraints = {1} }}",
            subject.Name,
            subject.Constraints);

        result.ShouldBe(expected);
    }
}
