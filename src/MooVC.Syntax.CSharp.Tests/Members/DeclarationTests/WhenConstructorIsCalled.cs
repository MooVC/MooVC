namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Generics;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "T";

    [Fact]
    public void GivenDefaultsThenDeclarationIsUnspecified()
    {
        // Act
        var subject = new Declaration();

        // Assert
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Parameters.ShouldBeEmpty();
        subject.IsUnspecified.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameter = new Parameter { Name = new Identifier(ParameterName) };

        // Act
        var subject = new Declaration
        {
            Name = new Identifier(DeclarationTestsData.DefaultName),
            Parameters = ImmutableArray.Create(parameter),
        };

        // Assert
        subject.Name.ShouldBe(new Identifier(DeclarationTestsData.DefaultName));
        subject.Parameters.ShouldBe(new[] { parameter });
        subject.IsUnspecified.ShouldBeFalse();
    }
}
