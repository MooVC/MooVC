namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "TValue";

    [Fact]
    public void GivenDefaultsThenParameterIsUnnamed()
    {
        // Act
        var subject = new Parameter();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Constraints.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Base(SymbolTestsData.CreateWithArgumentNames()),
        };

        // Act
        var subject = new Parameter
        {
            Name = new Identifier(ParameterName),
            Constraints = [constraint],
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(ParameterName));
        subject.Constraints.ShouldBe(new[] { constraint });
    }
}